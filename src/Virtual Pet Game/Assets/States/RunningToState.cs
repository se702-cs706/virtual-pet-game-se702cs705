using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class RunningToState : IState
{
    private AgentController _controller;
    private IStateActions _manager;
    private float _maxSpeed;
    private Transform _target;
    private IState _nextState;

    public RunningToState(float maxSpeed, Transform target, AgentController controller, IStateActions manager, [CanBeNull] IState nextState = null)
    {
        _target = target;
        _maxSpeed = maxSpeed;
        _controller = controller;
        _manager = manager;
        _nextState = nextState;
    }
    
    public void onStateEnter()
    {
        _controller.maxSpeed = _maxSpeed;
        _controller.target = _target.position;
        _controller.isMovingToTarget = true;

    }

    public IState onStateUpdate()
    {
        _controller.target = _target.position;

        if (!_controller.isMovingToTarget)
        {
            if (_nextState != null)
            {
                return _nextState;
            }
            return new WaitingState(null, _controller, _manager);
        }
        
        return null;
    }

    public void onStateExit()
    {
        
    }
}
