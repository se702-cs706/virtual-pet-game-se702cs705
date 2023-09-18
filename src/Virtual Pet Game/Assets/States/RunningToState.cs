using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class RunningToState : GoalState
{
    private float _maxSpeed;
    private Transform _target;

    public RunningToState(
        float maxSpeed, 
        Transform target, 
        AgentController controller, IStateActions manager, [CanBeNull] IState next = null) : 
        base(DogState.Moving, controller, manager, next)
    {
        _maxSpeed = maxSpeed;
        _target = target;
    }
    
    public override void onStateEnterChild()
    {
        _controller.maxSpeed = _maxSpeed;
        _controller.target = _target.position;
        _controller.isMovingToTarget = true;

    }

    public override IState onStateDuringUpdate()
    {
        return null;
    }

    public override bool goalCondition()
    {
        return !_controller.isMovingToTarget;
    }

    public override IState onGoalReached()
    {
        if (_next != null)
        {
            return _next;
        }
        return new WaitingState(5, _controller, _manager);
    }

    public override void onStateExit()
    {
        
    }

}
