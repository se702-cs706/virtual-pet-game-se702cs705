using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

/// <summary>
/// State pattern manager for the dog
/// </summary>
public class DogManager : MonoBehaviour
{
    private IState _currentState;
    private float time;
    [Header("Deps")] 
    [SerializeField] private AgentController _controller;

    [SerializeField] private Transform _transform;
    [Header("Params")] 
    [SerializeField] private float Energy = 10;
    [SerializeField] private float Excitement = 10;
    [SerializeField] private float EnergyDropRatePS = 0.01f;
    [SerializeField] private float ExcitementDropRatePS = 1f;

    public void Start()
    {
        _currentState = new RunningToState(1f, _transform, _controller);
    }

    private void Update()
    {
        var newState = _currentState.onStateUpdate();
        if (newState != null)
        {
            _currentState.onStateExit();
            _currentState = newState;
            _currentState.onStateEnter();
        }

        time -= Time.deltaTime;
        if (time < 0)
        {
            time += 1;
            Energy = Math.Max(0,Energy - EnergyDropRatePS);
            Excitement = Math.Max(0,Excitement - ExcitementDropRatePS);
        }
    }

    public float getEnergy()
    {
        return Energy;
    }
    
    public float getExcitement()
    {
        return Excitement;
    }
}
