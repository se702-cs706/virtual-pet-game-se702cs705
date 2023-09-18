using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Interactable;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class BowlController : MonoBehaviour
{
    // public bool isFilled;
    public BowlState bowlState;

    private void Start()
    {
        bowlState = BowlState.Empty;
    }

    private void Update()
    {

    }

    public void ChangeState(BowlState newState)
    {
        bowlState = newState;
    }
}