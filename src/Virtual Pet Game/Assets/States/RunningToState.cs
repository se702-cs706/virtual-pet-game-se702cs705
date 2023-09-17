using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningToState : IState
{
    private AgentController _controller;
    private DogManager _manager;
    private float _maxSpeed;
    private Transform _target;

    public RunningToState(float maxSpeed, Transform target, AgentController controller, DogManager manager)
    {
        _target = target;
        _maxSpeed = maxSpeed;
        _controller = controller;
        _manager = manager;
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
            return new WaitingState(null, _controller, _manager);
        }
        else
        {
            return null;
        }
    }

    public void onStateExit()
    {
        
    }
}
