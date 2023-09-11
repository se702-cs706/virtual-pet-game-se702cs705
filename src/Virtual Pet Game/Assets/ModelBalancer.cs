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
        var bodyDirection = -IKObject.transform.forward;
        if (_groundPointBack._groundPoint != Vector3.negativeInfinity && _groundPointFront._groundPoint != Vector3.negativeInfinity)
        {
            bodyDirection = _groundPointBack._groundPoint - _groundPointFront._groundPoint;
        }
        Debug.Log(bodyDirection);
        var normal = Vector3.Cross(IKObject.transform.right,bodyDirection);
        return normal;
    }

    void rotate(Vector3 normal)
    {
        IKObject.rotation = Quaternion.FromToRotation (IKObject.transform.up, normal) * IKObject.rotation;
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
