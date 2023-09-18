
using JetBrains.Annotations;

/// <summary>
/// State where the exit condition is reaching the goal.
/// </summary>
public abstract class GoalState : BaseState
{
    protected GoalState(DogState state, AgentController controller, IStateActions manager, [CanBeNull] IState next = null) : 
        base(state, controller, manager, next)
    {
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
            if (goalCondition())
            {
                return onGoalReached();
            }

            return null;
        }
    }

    public abstract IState onStateDuringUpdate();

    public abstract bool goalCondition();

    [NotNull] public abstract IState onGoalReached();
}