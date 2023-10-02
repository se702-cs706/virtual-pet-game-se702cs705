using System.Collections;
using System.Collections.Generic;
using Interactable;
using UnityEngine;

public class BowlController : MonoBehaviour
{
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

    // TODO: bowlState will change how the bowl looks (filled, empty)
    // Also will change to point of interest for dog?
}