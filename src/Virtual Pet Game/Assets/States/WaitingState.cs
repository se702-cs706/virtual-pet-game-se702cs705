using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaitingState : TimedState
{
    [CanBeNull] private Transform _lookAt;

    public WaitingState(
        float time, AgentController controller, IStateActions manager, 
        [CanBeNull] IState next = null, [CanBeNull] Transform lookAt = null) : 
        base(DogState.Idle, time, controller, manager, next)
    {
        _lookAt = lookAt;
    }

    public override void onStateEnterChild()
    {
        if (_lookAt != null)
        {
            _manager.setLookAt(_lookAt);
        }
    }

    public override IState onStateDuringUpdate()
    {
        if (_manager.getState() != DogState.Idle)
        {
            return new ActionState(_manager.getState(), _manager.getActionTime(),_controller, _manager);
        }

        return null;
    }

    public override IState onGoalReached()
    {
        if (_manager.PointOfInterest != null)
        {
            IState next = null;
            if (_manager.PointOfInterest.InterestType == InterestType.food)
            {
                next = new ActionState(DogState.Eat, _manager.PointOfInterest.InterestTime, _controller, _manager);
            }
            else if (_manager.PointOfInterest.InterestType == InterestType.play)
            {
                next = null;
            }
            else if (_manager.PointOfInterest.InterestType == InterestType.rest)
            {
                next = new ActionState(DogState.Rest, _manager.PointOfInterest.InterestTime, _controller, _manager);
            }
            
            _manager.PointOfInterest.canBeUsed = false;
            return new RunningToState(5, _manager.PointOfInterest.transform, _controller, _manager, next);
        }

        return new WanderingState(3, 10, _controller, _manager);
    }

    public override void onStateExit()
    {
        _manager.setLookAt(null);
    }

}
