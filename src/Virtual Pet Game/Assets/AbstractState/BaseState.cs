
using JetBrains.Annotations;

public abstract class BaseState : IState
{
    protected AgentController _controller;
    protected IStateActions _manager;
    protected IState _next;
    protected DogState _state;

    public BaseState(DogState state, AgentController controller, IStateActions manager, [CanBeNull] IState next = null)
    {
        _controller = controller;
        _manager = manager;
        _next = next;
        _state = state;
    }


    public void onStateEnter()
    {
        _manager.setState(_state);
        onStateEnterChild();
    }

    public abstract void onStateEnterChild();

    public abstract IState onStateUpdate();

    public abstract void onStateExit();
}