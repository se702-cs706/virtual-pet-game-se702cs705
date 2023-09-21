using System;
using System.Collections.Generic;
using PointOfInterestCode;
using States;
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
    private GameObject holding;

    [FormerlySerializedAs("_controller")]
    [Header("Deps")] 
    [SerializeField] private AgentController controller;

    [Header("Params")] 
    [SerializeField] private float Energy = 10;
    [SerializeField] private float Excitement = 10;
    [SerializeField] private float EnergyDropRatePS = 0.01f;
    [SerializeField] private float ExcitementDropRatePS = 1f;
    
    [Header("Speed Params")]
    [SerializeField] private float walkSpeed = 1;
    [SerializeField] private float runSpeed = 2;
    [SerializeField] private float sprintSpeed = 3;
    
    [Header("Presenter")]
    [SerializeField] ModelPresenter presenter;
    
    [Header("POIs")]
    [SerializeField] private List<PointOfInterest> pointsOfInterest;

    [SerializeField] private Transform playerTransform;
    public PointOfInterest PointOfInterest { get; set; }

    public void Start()
    {
        StateFactory.Initiate(this,controller);
        var stateFactory = StateFactory.getInstance();
        var next = StatesHelper.GetRunToSequence(stateFactory, runSpeed, 1f,7, playerTransform);
        _currentState = StatesHelper.GetActionState(stateFactory, DogState.Sit, 4, next);
        _currentState.onStateEnter();
    }

    private void Update()
    {
        //Debug.Log(_currentState.GetType()+ " -> State");

        if(controller.isOnNavMeshLink)
        {
            //Debug.Log(controller.jump);
        }

        HandleState();
        DropParams();
        UpdatePointOfInterest();
    }

    private void HandleState()
    {
        var newState = _currentState.onStateUpdate();
        if (newState != null)
        {
            _currentState.onStateExit();
            _currentState = newState;
            _currentState.onStateEnter();
        }
    }
    
    private void DropParams()
    {
        _time -= Time.deltaTime;
        if (_time < 0)
        {
            _time += 1;
            Energy = Math.Max(0,Energy - EnergyDropRatePS * controller._agent.velocity.magnitude);
            Excitement = Math.Max(0,Excitement - ExcitementDropRatePS);
        }
    }

    private void UpdatePointOfInterest()
    {
        if (pointsOfInterest.Count == 0)
        {
            PointOfInterest = null;
            return;
        }
        if (pointsOfInterest.Count == 1)
        {
            PointOfInterest = pointsOfInterest[0];
            return;
        }
        
        var position = transform.position;
        var mostInterestPoi = null as PointOfInterest;
        foreach (var poi in pointsOfInterest)
        {
            if (!poi.canBeUsed)
            {
                continue;
            }

            if (poi.canBeUsed && mostInterestPoi == null)
            {
                mostInterestPoi = poi;
            }
            
            if (poi.InterestType == InterestType.food)
            {
                poi.InterestLevel = poi.InheritInterestLevel + 10 - Energy;
            }
            
            if ((poi.transform.position - position).magnitude < poi.InterestRadius
                && poi.InterestLevel > mostInterestPoi.InterestLevel)
            {
                mostInterestPoi = poi;
            }
        }
        
        PointOfInterest = mostInterestPoi;
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
        //Debug.Log("state set -> " + state);
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

    public float getEnergy()
    {
        return Energy;
    }

    public void RestoreEnergy(float energy)
    {
        Energy += energy;
        Energy = Math.Max(Energy, 10);
    }

    public float getExcitement()
    {
        return Excitement;
    }

    public void RaiseExcitement(float excitement)
    {
        Excitement += excitement;
        Excitement = Math.Max(Excitement, 10);
    }

    public float getWalkSpeed()
    {
        return walkSpeed;
    }
    
    public float getRunSpeed()
    {
        return runSpeed;
    }
    
    public float getSprintSpeed()
    {
        return sprintSpeed;
    }

    public Transform getPlayerTransform()
    {
        return playerTransform;
    }

    public GameObject getHolding()
    {
        return holding;
    }

    public void setHolding(GameObject gameObject)
    {
        holding = gameObject;
    }
}