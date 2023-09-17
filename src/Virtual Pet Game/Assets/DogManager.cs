using System;
using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// State pattern manager for the dog
/// </summary>
public class DogManager : MonoBehaviour, IStateActions, IManagerModel
{
    private IState _currentState;
    private float _time;
    [SerializeField] private DogState _state;
    public float lastActionTime;
    public Transform lookAt;
    public Transform PointOfInterest { get; set; }

    [FormerlySerializedAs("_controller")]
    [Header("Deps")] 
    [SerializeField] private AgentController controller;

    [SerializeField] private Transform _transform;
    [Header("Params")] 
    [SerializeField] private float Energy = 10;
    [SerializeField] private float Excitement = 10;
    [SerializeField] private float EnergyDropRatePS = 0.01f;
    [SerializeField] private float ExcitementDropRatePS = 1f;
    
    [Header("Presenter")]
    [SerializeField] ModelPresenter presenter;
    
    [Header("POIs")]
    [SerializeField] private Transform[] _pointsOfInterest;

    public void Start()
    {

        _currentState = new RunningToState(3, _transform, controller, this);
        _currentState.onStateEnter();
    }

    private void Update()
    {
        Debug.Log(_currentState.GetType()+ " -> State");
        
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
            Energy = Math.Max(0,Energy - EnergyDropRatePS * controller._agent.velocity.magnitude);
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


    /// <summary>
    /// called by the state to start an action
    /// </summary>
    /// <param name="state"></param>
    public void setState(DogState state)
    {
        _state = state;
        presenter.startAction(state);
    }

    public void resetTime()
    {
        lastActionTime = 0;
    }

    public float getActionTime()
    {
        return lastActionTime;
    }

    public void startStateAction(DogState state, float time)
    {
        _state = state;
        lastActionTime = time;
    }

    public DogState getState()
    {
        return _state;
    }
    
    public void setLookAt(Transform lookAt)
    {
        //TODO implement sub
    }
}
