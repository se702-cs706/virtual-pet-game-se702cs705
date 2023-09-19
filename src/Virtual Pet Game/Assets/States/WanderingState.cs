using System.Collections;
using System.Collections.Generic;
using States;
using UnityEngine;

public class WanderingState : TimedState, InitializableState<WanderingStateParams>
{
    private float _maxSpeed;
    
    public void OnStateBuild(WanderingStateParams param, DogManager manager, AgentController controller)
    {
        _maxSpeed = param._maxSpeed;
        _state = DogState.Moving;
        base.OnStateBuild(param, manager, controller);
    }

    public override void onStateEnterChild()
    {
        _controller.maxSpeed = _maxSpeed;
    }

    public override IState onStateDuringUpdate()
    {
        if (!_controller.isMovingToTarget)
        {
            var randPos = new Vector3(Random.Range(-5, 5), _controller._agent.transform.position.y, Random.Range(-5, 5)) + _controller._agent.transform.position;
            if (randPos.x > 15)
            {
                randPos.x = 15;
            }

            if (randPos.x < -15)
            {
                randPos.x = -15;
            }

            if (randPos.z > 10)
            {
                randPos.x = 10;
            }

            if (randPos.z < -20)
            {
                randPos.z = -20;
            }
            _controller.target = randPos;
            _controller.isMovingToTarget = true;
            Debug.Log(_controller.target);
        }

        if (_manager.getState() == DogState.Idle)
        {
            return _stateFactory.BuildState<WaitingState, WaitingStateParams>(new WaitingStateParams()
            {
                _time = 10,
            });
        }

        return null;
    }

    public override IState onGoalReached()
    {
        return StatesHelper.GetPostWanderWaitingState( _manager, _stateFactory);
    }

    public override void onStateExit()
    {
    }


}
