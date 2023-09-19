using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using States;
using UnityEngine;

public class RunningToState : GoalState, InitializableState<RunningToStateParams>
{
    private float _maxSpeed;
    private Vector3 _target;
    
    public void OnStateBuild(RunningToStateParams param, DogManager manager, AgentController controller)
    {
        _maxSpeed = param._maxSpeed;
        _target = param._target;
        _state = DogState.Moving;
        base.OnStateBuild(param, manager, controller);
    }
    
    public override void onStateEnterChild()
    {
        _controller.maxSpeed = _maxSpeed;
        _controller.target = _target;
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
        return _stateFactory.BuildState<WaitingState, WaitingStateParams>(new WaitingStateParams()
        {
            _time = 3,
        });
    }

    public override void onStateExit()
    {
        
    }

}
