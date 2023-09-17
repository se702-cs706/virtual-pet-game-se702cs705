using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using JetBrains.Annotations;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AgentController : MonoBehaviour
{
    public Vector3 target { get; set; }
    public bool isMovingToTarget { get; set; }
    public float maxSpeed { get; set; }
    private NavMeshAgent _agent;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        _agent.speed = maxSpeed;
        Debug.Log("Target: " + target);
        Debug.Log("MaxSpeed: " + maxSpeed);
        Debug.Log("Is moving to target: " + isMovingToTarget);
        
        if (isMovingToTarget)
        {
            if (transform.position.x - target.x < 0.05f && transform.position.z - target.z < 0.05f)
            {
                isMovingToTarget = false;
            }
            _agent.destination = target;
        }
    }
}
