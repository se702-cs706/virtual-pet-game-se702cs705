using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using JetBrains.Annotations;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AgentController : MonoBehaviour
{
    public Transform target { get; set; }
    public bool isMovingToTarget { get; set; }
    public float maxSpeed { get; set; }
    public NavMeshAgent _agent { get; private set; }

    public bool isOnNavMeshLink { get; private set; }

    public JumpType jump { get; private set;  }

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        _agent.speed = maxSpeed;
        //Debug.Log("Target: " + target);
        //Debug.Log("MaxSpeed: " + maxSpeed);
        //Debug.Log("Is moving to target: " + isMovingToTarget);
        
        if (isMovingToTarget)
        {
            if (Math.Abs(transform.position.x - target.position.x) < 0.05f && Math.Abs(transform.position.z - target.position.z) < 0.05f)
            {
                isMovingToTarget = false;
            }
            _agent.destination = target.position;
        }

        isOnNavMeshLink = _agent.isOnOffMeshLink;
        if (isOnNavMeshLink == true)
        {

            OffMeshLinkData data = _agent.currentOffMeshLinkData;
            Vector3 start = data.startPos;
            Vector3 end = data.endPos;

             if (Mathf.Tan(20f * 0.0174533f) >= Math.Abs(end.y - start.y) / (Math.Pow(Math.Pow(end.x - start.x, 2) + Math.Pow(end.z - start.z, 2), 1f / 2f)) )
            {

                jump = JumpType.Across;

            } else
            {

                if (end.y - start.y > 0)
                {

                    jump = JumpType.Up;

                } else
                {

                    jump = JumpType.Down;

                }

            }

        }
    }
}
