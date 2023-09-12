using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ModelPresenter : MonoBehaviour
{
    [Header("Agent")] 
    [SerializeField] private NavMeshAgent agent;

    [SerializeField] private ModelBalancer model;

    [SerializeField] private float maxSpeed = 1.3f;

    [SerializeField] private float multiplier;
    [SerializeField] private float predictionRate;
    [Header("View")] 
    [SerializeField] private AnimatorController view;

    private void FixedUpdate()
    {
        // calculate values
        var lookPos = agent.transform.position + agent.velocity * predictionRate;
        var direction = new Vector3(lookPos.x - transform.position.x, transform.forward.y, lookPos.z - transform.position.z);
        if (direction.magnitude < 0.1f)
        {
            direction = transform.forward;
        }
        var angle = Vector3.SignedAngle(transform.forward, direction, Vector3.up);
        
        // set all values
        if (angle > 30 || angle < -30)
        {
            view.setDrift(angle / 30);
        }
        else
        {
            view.setDrift(0);
        }

        model.setLook(direction);
        var speed = Math.Min(multiplier * direction.magnitude, maxSpeed);
        view.setSpeed(speed);
    }
}
