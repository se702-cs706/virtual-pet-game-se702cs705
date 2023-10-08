using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using PointOfInterestCode;
using States;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaitingState : TimedState, InitializableState<WaitingStateParams>
{
    [CanBeNull] private PointOfInterest Following;
    
    public void OnStateBuild(WaitingStateParams param, DogManager manager, AgentController controller)
    {
        Following = param._lookAt;
        _state = DogState.Idle;
        base.OnStateBuild(param, manager, controller);
    }

    public override void onStateEnterChild()
    {
    }

    public override IState onStateDuringUpdate()
    {
        if (_manager.getState() != DogState.Idle)
        {
            var time = _manager.getActionTime();
            return StatesHelper.GetPlayerActionState(_stateFactory, _manager.getState(), time, 5);
        }

        if (_manager.PointOfInterest.InterestLevel > 100)
        {
            return StatesHelper.GetPOIActionStates(_manager, _stateFactory);
        }

        if (Following != null && (_controller._agent.transform.position - Following.transform.position).magnitude >=
            Following.InteractionDistance + 0.2f)
        {
            return StatesHelper.GetRunToSequence(_stateFactory, _manager.getRunSpeed(), Following.InteractionDistance,7,Following.transform, lookAt: Following);
        }

        return null;
    }

    public override IState onGoalReached()
    {
        return StatesHelper.GetPOIActionStates( _manager, _stateFactory);
    }

    public override void onStateExit()
    {
        _manager.setLookAt(null);
    }

}
