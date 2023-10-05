using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPoint : MonoBehaviour
{
    [SerializeField] float raycastDistance = 1;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] ModelBalancer _modelBalancer;
    public Vector3 _groundPoint { get; private set; } = Vector3.negativeInfinity;
    public Vector3 _normal { get; private set; } = Vector3.up;

    void FixedUpdate()
    {
        FindGroundPoint(transform.up);
        Debug.DrawLine(transform.position,transform.position + _normal, Color.blue);
    }
    
    void FindGroundPoint(Vector3 groundNormal)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -groundNormal, out hit, raycastDistance, groundLayer))
        {
            _groundPoint = hit.point;
            _normal = hit.normal;
        }
        else
        {
            _groundPoint = Vector3.negativeInfinity;
            _normal = Vector3.up;
        }
    }
}
