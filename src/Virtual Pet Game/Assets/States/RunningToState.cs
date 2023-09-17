using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningToState : IState
{
    private AgentController _controller;
    private float _maxSpeed;
    private Vector3 _target;

    public RunningToState(float maxSpeed, Vector3 target, AgentController controller)
    {
        _target = target;
        _maxSpeed = maxSpeed;
        _controller = controller;
    }
    
    public void onStateEnter()
    {
        _controller.maxSpeed = _maxSpeed;
        _controller.target = _target;
        _controller.isMovingToTarget = true;

    }

    public IState onStateUpdate()
    {

        if (!_controller.isMovingToTarget)
        {
            return new WaitingState();
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
