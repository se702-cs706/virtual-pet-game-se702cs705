using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public abstract class TimedState : BaseState
{
    private float _time;
    
    protected TimedState(float time, AgentController controller, IStateActions manager) : base(controller, manager)
    {
        _time = time;
    }

    public override IState onStateUpdate()
    {
        var res = onTimeRunningUpdate();
        if (res != null)
        {
            return res;
        }
        else
        {
            _time -= Time.deltaTime;
            if (_time <= 0)
            {
                return onTimeExpireUpdate();
            }

            return null;
        }
    }

    public abstract IState onTimeRunningUpdate();

    public abstract IState onTimeExpireUpdate();
}