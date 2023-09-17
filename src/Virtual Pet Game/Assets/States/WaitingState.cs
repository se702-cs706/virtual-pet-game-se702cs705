using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaitingState : IState
{
    private AgentController _controller;
    private IStateActions _manager;
    private float _time;
    private IState _nextState;

    [CanBeNull] private Transform _lookAt;

    public WaitingState([CanBeNull] Transform lookAt, AgentController controller, IStateActions manager, float? time = 10, [CanBeNull] IState nextState = null)
    {
        _controller = controller;
        _manager = manager;
        _lookAt = lookAt;
        _time = time ?? 10;
        _nextState = nextState;
    }

    public void onStateEnter()
    {
        _manager.setState(DogState.Idle);
        
        if (_lookAt != null)
        {
            _manager.setLookAt(_lookAt);
        }
    }

    public IState onStateUpdate()
    {
        
        if (_manager.getState() != DogState.Idle)
        {
            return new ActionState(_manager.getState(), _controller, _manager, _manager.getActionTime());
        }
        
        if (_time > 0)
        {
            _time -= Time.deltaTime;
            return null;
        }
        
        if (_manager.PointOfInterest != null)
        {
            IState next = null;
            if (_manager.PointOfInterest.InterestType == InterestType.food)
            {
                next = new ActionState(DogState.Sit, _controller, _manager, _manager.PointOfInterest.InterestTime);
            }
            else if (_manager.PointOfInterest.InterestType == InterestType.play)
            {
                next = null;
            }
            else if (_manager.PointOfInterest.InterestType == InterestType.rest)
            {
                next = new ActionState(DogState.Crouch, _controller, _manager, _manager.PointOfInterest.InterestTime);
            }
            
            _manager.PointOfInterest.canBeUsed = false;
            return new RunningToState(5, _manager.PointOfInterest.transform, _controller, _manager, next);
        }

        return null;
    }

    public void onStateExit()
    {
        _manager.setLookAt(null);
    }
}
