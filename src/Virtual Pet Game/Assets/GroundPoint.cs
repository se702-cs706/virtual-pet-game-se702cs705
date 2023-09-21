using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPoint : MonoBehaviour
{
    [SerializeField] float raycastDistance = 1;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] ModelBalancer _modelBalancer;
    public Vector3 _groundPoint { get; private set; } = Vector3.negativeInfinity;

    void FixedUpdate()
    {
        FindGroundPoint(Vector3.up);
    }
    
    void FindGroundPoint(Vector3 groundNormal)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -groundNormal, out hit, raycastDistance, groundLayer))
        {
            _groundPoint = hit.point;   
        }
        else
        {
            _groundPoint = Vector3.negativeInfinity;
        }
    }
}
