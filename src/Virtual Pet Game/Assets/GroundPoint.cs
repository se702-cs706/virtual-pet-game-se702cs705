using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPoint : MonoBehaviour
{
    [SerializeField] float raycastDistance = 1;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] ModelBalancer _modelBalancer;
    public Vector3 _groundPoint { get; private set; }

    void FixedUpdate()
    {
        FindGroundPoint(Vector3.up);
    }
    
    void FindGroundPoint(Vector3 groundNormal)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -groundNormal, out hit, raycastDistance))
        {
            _groundPoint = hit.point;   
        }
    }
}
