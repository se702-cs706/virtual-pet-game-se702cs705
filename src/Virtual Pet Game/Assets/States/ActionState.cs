using System.Text;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class ActionState : IState
{
    private AgentController _controller;
    private IStateActions _manager;
    private DogState _state;
    private float _time;
    private float sTime;

    public ActionState(DogState state, AgentController controller, IStateActions manager, float? time = null)
    {
        _state = state;
        _controller = controller;
        _manager = manager;
        _time = time ?? 0;
    }
    
    public void onStateEnter()
    {
        sTime = 1;
        
        _manager.resetTime();
        _manager.setState(_state);
        _controller.isMovingToTarget = false;
        if (_time == 0)
        {
            _time = Random.Range(5, 20);
        }
    }

    public IState onStateUpdate()
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
        
        
        _time -= Time.deltaTime;
        if (_time < 0)
        {
            if (_manager.getEnergy() > 8)
            {
                return new WanderingState(7, 14,_controller, _manager);
            }
            return new WaitingState(null,  _controller, _manager);
        }
        
        return null;
    }

    public void onStateExit()
    {
    }
}
