using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using Random = System.Random;

public class WaitingState : IState
{
    private AgentController _controller;
    private IStateActions _manager;

    [CanBeNull] private Transform _lookAt;

    public WaitingState([CanBeNull] Transform lookAt, AgentController controller, IStateActions manager)
    {
        _controller = controller;
        _manager = manager;
        _lookAt = lookAt;
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

        return null;
    }

    public void onStateExit()
    {
        _manager.setLookAt(null);
    }
}
