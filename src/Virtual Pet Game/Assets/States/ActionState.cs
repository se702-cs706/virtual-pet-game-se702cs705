using System.Text;
using JetBrains.Annotations;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class ActionState : TimedState
{
    private float sTime;
    
    public ActionState(DogState state, float time, AgentController controller, IStateActions manager, [CanBeNull] IState next = null) : 
        base(state, time, controller, manager, next)
    {
    }
    
    public override void onStateEnter()
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
            return new WanderingState(7, 14,_controller, _manager);
        }
        return new WaitingState(5,  _controller, _manager);
    }

    public override void onStateExit()
    {
    }

}
