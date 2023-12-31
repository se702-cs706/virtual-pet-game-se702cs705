using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using States;
using UnityEngine;

public class RunningToState : GoalState, InitializableState<RunningToStateParams>
{
    private float _maxSpeed;
    private Transform _target;
    private float _distance;
    
    public void OnStateBuild(RunningToStateParams param, DogManager manager, AgentController controller)
    {
        _maxSpeed = param._maxSpeed;
        _target = param._target;
        _distance = param.distance;
        _state = DogState.Moving;
        base.OnStateBuild(param, manager, controller);
    }
    
    public override void onStateEnterChild()
    {
        _controller.maxSpeed = _maxSpeed;
        _controller.target = _target.position + (_controller.transform.position - _target.position).normalized * _distance;
        _controller.isMovingToTarget = true;

    }

    public override IState onStateDuringUpdate()
    {
        _controller.target = _target.position + (_controller.transform.position - _target.position).normalized * _distance;

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

        return StatesHelper.GetIdleState(_stateFactory);
    }

    public override void onStateExit()
    {
        
    }

}
