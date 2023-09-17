using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using JetBrains.Annotations;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AgentController : MonoBehaviour
{
    public Transform target { private get; set; }
    public bool isMovingToTarget { private get; set; }
    public float maxSpeed { private get; set; }
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
        
        if (isMovingToTarget)
        {
            _agent.destination = target.position;
        }
        else
        {
            _agent.destination = transform.position;
        }
    }
}
