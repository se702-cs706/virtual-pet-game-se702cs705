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
        var lookPos = agent.transform.position + agent.velocity * predictionRate;
        var direction = new Vector3(lookPos.x - transform.position.x, transform.forward.y, lookPos.z - transform.position.z);
        model.setLook(direction);
        view.setSpeed(Math.Min(multiplier * direction.magnitude, maxSpeed));
    }
}
