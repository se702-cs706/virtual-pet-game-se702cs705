using System.Text;
using JetBrains.Annotations;
using States;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class ActionState : TimedState, InitializableState<TimedStateParams>
{
    public void OnStateBuild(TimedStateParams param, DogManager manager, AgentController controller)
    {
        _state = param._state;
        base.OnStateBuild(param,manager, controller);
    }
    
    public override void onStateEnterChild()
    {
        _manager.resetTime();
        _controller.isMovingToTarget = false;
    }

    public override IState onStateDuringUpdate()
    {
        return null;
    }

    public override IState onGoalReached()
    {
        if (_manager.getEnergy() > 8)
        {
            return StatesHelper.GetZoomiesState(_manager, _stateFactory);
        }

        return StatesHelper.GetIdleState(_stateFactory);
    }

    public override void onStateExit()
    {
    }

}
