using JetBrains.Annotations;
using States;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

/// <summary>
/// State where the goal to exit is running the time to zero.
/// </summary>
public abstract class TimedState : GoalState, InitializableState<TimedStateParams>
{
    protected float _time;
    
    public void OnStateBuild(TimedStateParams param, DogManager manager, AgentController controller)
    {
        _time = param._time;
        base.OnStateBuild(param, manager, controller);
    }
    
    public override IState onStateUpdate()
    {
        var res = onStateDuringUpdate();
        if (res != null)
        {
            return res;
        }

        _time -= Time.deltaTime;
        if (goalCondition())
        {
            if (_next != null)
            {
                return _next;
            }
                
            return onGoalReached();
        }

        return null;
    }

    public override bool goalCondition()
    {
        Debug.Log("condition met");
        return _time <= 0;
    }
}