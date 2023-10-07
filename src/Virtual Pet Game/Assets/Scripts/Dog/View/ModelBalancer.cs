using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelBalancer : MonoBehaviour
{
    [Header("IK object")] 
    [SerializeField] private Transform IKObject;
    
    [Header("Ground Points")]
    [SerializeField] private GroundPoint _groundPointFront;
    [SerializeField] private GroundPoint _groundPointBack;

    [Header("Direction")] 
    [SerializeField] private Vector3 lookDirection;

    [SerializeField] private float rotationDamper;
    [SerializeField] private float tileDamper;
    
    public Vector3 GroundNormal { get; private set; } = Vector3.up;

    // Update is called once per frame
    void FixedUpdate()
    {
        shift();
        GroundNormal = getGroundNormal();
        rotate(GroundNormal);
    }

    Vector3 getGroundNormal()
    {
        var groundNormal = Vector3.up;
        if (_groundPointBack._groundPoint != Vector3.negativeInfinity && _groundPointFront._groundPoint != Vector3.negativeInfinity)
        {
            groundNormal = _groundPointFront._normal.normalized + _groundPointBack._normal.normalized;
        }

        var tilt = Vector3.Cross(IKObject.transform.forward, groundNormal);
        
        var bodyDirection = -IKObject.transform.forward;
        if (_groundPointBack._groundPoint != Vector3.negativeInfinity && _groundPointFront._groundPoint != Vector3.negativeInfinity)
        {
            bodyDirection = _groundPointBack._groundPoint - _groundPointFront._groundPoint;
        }
        //Debug.Log(bodyDirection);
        var dogNormal = Vector3.Cross(-tilt,bodyDirection);
        Debug.DrawLine(IKObject.transform.position,IKObject.transform.position + dogNormal, Color.red);
        return dogNormal;
    }

    void rotate(Vector3 normal)
    {
        //rotate tile and slope
        var desiredTiltRotation = Quaternion.FromToRotation (IKObject.transform.up, normal) * IKObject.rotation;
        IKObject.rotation = Quaternion.Lerp(transform.rotation, desiredTiltRotation, Time.deltaTime * tileDamper);
        //rotate look direction
        var flatForward = -Vector3.Cross(Vector3.up, IKObject.right);
        var desiredLookRotation = Quaternion.FromToRotation (flatForward,new Vector3(lookDirection.x, flatForward.y,lookDirection.z)) * IKObject.rotation;
        IKObject.rotation = Quaternion.Lerp(transform.rotation, desiredLookRotation, Time.deltaTime * rotationDamper);
    }

    public void setLook(Vector3 lookDirection)
    {
        this.lookDirection = lookDirection;
    }

    void shift()
    {
        float groundZero = 0;
        if (_groundPointBack._groundPoint != Vector3.negativeInfinity && _groundPointFront._groundPoint != Vector3.negativeInfinity)
        {
            groundZero = (_groundPointBack._groundPoint.y + _groundPointFront._groundPoint.y) / 2;
        }
        var IKpos = IKObject.transform.position;
        var pos = transform.position;
        IKObject.transform.Translate(0,groundZero - IKpos.y,0);
    }
}
