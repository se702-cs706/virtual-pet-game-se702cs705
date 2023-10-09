using System.Collections;
using System.Collections.Generic;
using States;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

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
            var randPos = Vector3.negativeInfinity;
            var path = new NavMeshPath();
            do
            {
                var position = _controller._agent.transform.position;
                randPos =
                    new Vector3(Random.Range(-6, 6), position.y, Random.Range(-6, 6)) +
                    position;
            } while (!_controller._agent.CalculatePath(randPos, path));

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

        if (_manager.GetPointOfInterest().InterestLevel > 100)
        {
            return StatesHelper.GetPOIActionStates(_manager, _stateFactory);
        }

        return null;
    }

    public override IState onGoalReached()
    {
        return StatesHelper.GetPOIActionStates( _manager, _stateFactory);
    }

    public override void onStateExit()
    {
    }


}
