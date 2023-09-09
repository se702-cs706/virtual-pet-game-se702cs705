using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelBalancer : MonoBehaviour
{
    [SerializeField] private GroundPoint _groundPointFront;
    [SerializeField] private GroundPoint _groundPointBack;
    public Vector3 _groundNormal { get; private set; } = Vector3.up;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
