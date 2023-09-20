using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Attached to a point of interest object that the dog can interact with
/// </summary>
public class PointOfInterest : MonoBehaviour
{
    [SerializeField] public float InheritInterestLevel = 10;
    [SerializeField] public float InterestLevel;
    [SerializeField] public float InterestRadius = 5;
    [SerializeField] public float InteractionDistance = 0;
    [SerializeField] public float InterestTime = 10;
    [SerializeField] public bool canBeUsed = true;
    [SerializeField] private float InheritInterestCooldown = 0;
    private float InterestCooldown = 0;
    [SerializeField] public InterestType InterestType;

    private void Start()
    {
        InterestCooldown = InheritInterestCooldown;
    }

    private void Update()
    {
        if(canBeUsed == false)
        {
            InterestCooldown -= Time.deltaTime;
            if(InterestCooldown <= 0)
            {
                canBeUsed = true;
                InterestCooldown = InheritInterestCooldown;
            }
        }
    }
}
