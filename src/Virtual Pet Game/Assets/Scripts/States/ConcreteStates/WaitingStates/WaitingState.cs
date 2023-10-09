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
            return StatesHelper.GetPlayerActionState(_stateFactory, _manager.getState(), time, 5, Following);
        }

        if (_manager.GetPointOfInterest().InterestLevel > 100)
        {
            _manager.setExcitement(_manager.getExcitement() + 3);
            return StatesHelper.GetPOIActionStates(_manager, _stateFactory);
        }

        if (Following != null &&
            _manager.getExcitement() > 5 &&
            (_controller._agent.transform.position - Following.transform.position).magnitude >=
            Following.InteractionDistance + 0.4f)
        {
            _manager.setExcitement(_manager.getExcitement() - 4);
            return StatesHelper.GetRunToSequence(_stateFactory, _manager.getRunSpeed(), Following.InteractionDistance,7,Following.transform, lookAt: Following);
        }
        if (Following != null &&
             _manager.getExcitement() < 5 &&
             (_controller._agent.transform.position - Following.transform.position).magnitude >=
             Following.InteractionDistance + 0.4f)
        {
            return getFinishedState();
        }

        return null;
    }

    public override IState onGoalReached()
    {
        return getFinishedState();
    }

    public override void onStateExit()
    {
    }

    private IState getFinishedState()
    {
        return StatesHelper.GetPOIActionStates( _manager, _stateFactory);
    }

}
