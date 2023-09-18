
public abstract class BaseState : IState
{
    protected AgentController _controller;
    protected IStateActions _manager;

    public BaseState(AgentController controller, IStateActions manager)
    {
        _controller = controller;
        _manager = manager;
    }


    public abstract void onStateEnter();

    public abstract IState onStateUpdate();

    public abstract void onStateExit();
}