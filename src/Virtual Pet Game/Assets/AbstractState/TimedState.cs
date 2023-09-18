using JetBrains.Annotations;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

/// <summary>
/// State where the goal to exit is running the time to zero.
/// </summary>
public abstract class TimedState : GoalState
{
    protected float _time;
    
    protected TimedState(DogState state, float time, AgentController controller, IStateActions manager, [CanBeNull] IState next = null) : 
        base(state, controller, manager, next)
    {
        _time = time;
    }

    public override IState onStateUpdate()
    {
        var res = onStateDuringUpdate();
        if (res != null)
        {
            return res;
        }
        else
        {
            _time -= Time.deltaTime;
            if (goalCondition())
            {
                return onGoalReached();
            }

            return null;
        }
    }

    public override bool goalCondition()
    {
        return _time <= 0;
    }
}