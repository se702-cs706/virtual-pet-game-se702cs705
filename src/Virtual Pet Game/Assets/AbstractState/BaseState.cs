
using JetBrains.Annotations;
using States;
using Unity.VisualScripting;
using UnityEngine;

public abstract class BaseState : IState, InitializableState<BaseStateParams>
{
    protected AgentController _controller;
    protected IStateActions _manager;
    protected IState _next;
    protected DogState _state;
    protected StateFactory _stateFactory;
    
    public void OnStateBuild(BaseStateParams param, DogManager manager, AgentController controller)
    {
        _controller = controller;
        _manager = manager;
        _next = param._next;
        _stateFactory = StateFactory.getInstance();
    }

    public void onStateEnter()
    {
        Debug.Log("Entered -> " + GetType() + ", with next being: " + _next?.GetType());
        _manager.setState(_state);
        onStateEnterChild();
    }

    public abstract void onStateEnterChild();

    public abstract IState onStateUpdate();

    public abstract void onStateExit();
}