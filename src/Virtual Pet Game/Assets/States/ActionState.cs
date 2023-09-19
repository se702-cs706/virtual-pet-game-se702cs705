using System.Text;
using JetBrains.Annotations;
using States;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class ActionState : TimedState, InitializableState<TimedStateParams>
{
    private float sTime;
    
    public void OnStateBuild(TimedStateParams param, DogManager manager, AgentController controller)
    {
        _state = param._state;
        base.OnStateBuild(param,manager, controller);
    }
    
    public override void onStateEnterChild()
    {
        sTime = 1;
        
        _manager.resetTime();
        _controller.isMovingToTarget = false;
    }

    public override IState onStateDuringUpdate()
    {
        sTime -= Time.deltaTime;
        if (sTime <= 0)
        {
            sTime += 1;
            if (_state == DogState.Eat)
            {
                _manager.RestoreEnergy(0.5f);
            }
        }

        return null;
    }

    public override IState onGoalReached()
    {
        if (_manager.getEnergy() > 8)
        {
            return StatesHelper.GetZoomiesState(_stateFactory);
        }

        return StatesHelper.GetIdleState(_stateFactory);
    }

    public override void onStateExit()
    {
    }

}
