using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using States;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaitingState : TimedState, InitializableState<WaitingStateParams>
{
    [CanBeNull] private Transform _lookAt;
    
    public void OnStateBuild(WaitingStateParams param, DogManager manager, AgentController controller)
    {
        _lookAt = param._lookAt;
        _state = DogState.Idle;
        base.OnStateBuild(param, manager, controller);
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
            var time = _manager.getActionTime();
            return StatesHelper.GetPlayerActionState(_stateFactory, _manager.getState(), time, 5);
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
