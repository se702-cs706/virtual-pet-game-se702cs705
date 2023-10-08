using System.Collections;
using System.Collections.Generic;
using States;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// singleton factory for states.
/// </summary>
public class StateFactory
{
    private DogManager _manager;
    private AgentController _controller;
    private static StateFactory _stateFactory;    
    
    /// <summary>
    /// always reloads the state factory as static objects does not get reset when reloading scene.
    /// </summary>
    /// <param name="manager"> Current dog manager</param>
    /// <param name="controller"> Current NMA controller</param>
    public static void Initiate(DogManager manager, AgentController controller)
    {
        _stateFactory = new StateFactory();
        _stateFactory._manager = manager;
        _stateFactory._controller = controller;
    }
    
    public static StateFactory getInstance()
    {
        if(_stateFactory == null)
            throw new System.Exception("StateFactory not initiated");
        
        return _stateFactory;
    }
    
    public IState BuildState<T, Tparam>(Tparam param) where Tparam : IStateParams where T : IState, InitializableState<Tparam>, new()
    {
        var res = new T();
        res.OnStateBuild(param, _manager, _controller);
        return res;
    }
}
