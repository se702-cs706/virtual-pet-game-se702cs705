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
        GroundNormal = getGroundNormal();
        rotate(GroundNormal);
    }

    Vector3 getGroundNormal()
    {
        var bodyDirection = _groundPointBack._groundPoint - _groundPointFront._groundPoint;
        Debug.Log(bodyDirection);
        var normal = Vector3.Cross(IKObject.transform.right,bodyDirection);
        return normal;
    }

    void rotate(Vector3 normal)
    {
        IKObject.rotation = Quaternion.FromToRotation (IKObject.transform.up, normal) * IKObject.rotation;
    }
}
