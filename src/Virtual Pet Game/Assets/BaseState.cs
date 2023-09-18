
using JetBrains.Annotations;

public abstract class BaseState : IState
{
    protected AgentController _controller;
    protected IStateActions _manager;
    protected IState _next;

    public BaseState(AgentController controller, IStateActions manager, [CanBeNull] IState next = null)
    {
        _controller = controller;
        _manager = manager;
        _next = next;
    }


    public abstract void onStateEnter();

    public abstract IState onStateUpdate();

    public abstract void onStateExit();
}