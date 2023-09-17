using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// State pattern manager for the dog
/// </summary>
public class DogManager : MonoBehaviour
{
    private IState _currentState;
    [Header("Params")] 
    [SerializeField] private float Energy;
    [SerializeField] private float Excitement;

    private void Update()
    {
        var newState = _currentState.onStateUpdate();
        if (newState != null)
        {
            _currentState.onStateExit();
            _currentState = newState;
            _currentState.onStateEnter();
        }
    }
}
