using System;
using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// State pattern manager for the dog
/// </summary>
public class DogManager : MonoBehaviour
{
    private IState _currentState;
    private float _time;
    [FormerlySerializedAs("_controller")]
    [Header("Deps")] 
    [SerializeField] private AgentController controller;

    [SerializeField] private Transform _transform;
    [Header("Params")] 
    [SerializeField] private float Energy = 10;
    [SerializeField] private float Excitement = 10;
    [SerializeField] private float EnergyDropRatePS = 0.01f;
    [SerializeField] private float ExcitementDropRatePS = 1f;

    public void Start()
    {

        _currentState = new RunningToState(1f, _transform, controller);
        _currentState.onStateEnter();
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

        _time -= Time.deltaTime;
        if (_time < 0)
        {
            _time += 1;
            Energy = Math.Max(0,Energy - EnergyDropRatePS);
            Excitement = Math.Max(0,Excitement - ExcitementDropRatePS);
        }
    }

    public float GetEnergy()
    {
        return Energy;
    }
    
    public float GetExcitement()
    {
        return Excitement;
    }
}
