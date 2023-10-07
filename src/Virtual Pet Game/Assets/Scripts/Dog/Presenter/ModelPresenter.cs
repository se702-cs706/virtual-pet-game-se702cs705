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
    [SerializeField] private float minSpeed = 1.3f;
    [SerializeField] private float stopRange = 0.2f;
    [SerializeField] private float acceleration = 0.3f;
    private float speed = 0;

    [SerializeField] private float multiplier;
    [SerializeField] private float predictionRate;
    [SerializeField] private float eatingRate;
    [Header("View")] 
    [SerializeField] private AnimatorController view;

    private void FixedUpdate()
    {
        // calculate values
        var lookPos = agent.transform.position + agent.velocity * predictionRate;
        var direction = new Vector3(lookPos.x - transform.position.x, transform.forward.y, lookPos.z - transform.position.z);

        var tCappedSpeed = Math.Min(direction.magnitude * multiplier, maxSpeed);
        var ltCappedSpeed = Math.Max(tCappedSpeed, minSpeed);
        if (direction.magnitude < stopRange)
        {
            speed = Mathf.Lerp(speed, 0, Time.fixedDeltaTime * acceleration);
        }
        else
        {
            speed = Mathf.Lerp(speed, ltCappedSpeed, Time.fixedDeltaTime * acceleration);
        }
        
        // set all values
        model.setLook(direction);
        view.setSpeed(speed);
        
        // set the angle for drift
        var angle = Vector3.SignedAngle(transform.forward, direction, Vector3.up);
        if (angle > 20 || angle < -20)
        {
            view.setDrift(angle / 199);
        }
        else
        {
            view.setDrift(0);
        }

    }

    public void startAction(DogState state)
    {
        view.setState(state);
    }
}
