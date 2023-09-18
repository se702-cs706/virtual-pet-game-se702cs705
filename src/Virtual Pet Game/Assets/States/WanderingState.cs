using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingState : TimedState
{
    private float _maxSpeed;
    
    public WanderingState(float maxSpeed, float time, AgentController controller, IStateActions manager) : 
        base(DogState.Moving, time, controller, manager)
    {
        _maxSpeed = maxSpeed;
    }
    
    public override void onStateEnter()
    {
        _controller.maxSpeed = _maxSpeed;
    }

    public override IState onStateDuringUpdate()
    {
        if (!_controller.isMovingToTarget)
        {
            var randPos = new Vector3(Random.Range(-5, 5), _controller._agent.transform.position.y, Random.Range(-5, 5));
            _controller.target = randPos + _controller._agent.transform.position;
            _controller.isMovingToTarget = true;
        }

        if (_manager.getState() == DogState.Idle)
        {
            return new WaitingState(null, _controller, _manager);
        }

        return null;
    }

    public override IState onGoalReached()
    {
        if (_manager.PointOfInterest != null)
        {
            IState next = null;
            if (_manager.PointOfInterest.InterestType == InterestType.food)
            {
                next = new ActionState(DogState.Eat, _manager.PointOfInterest.InterestTime, _controller, _manager);
            }
            else if (_manager.PointOfInterest.InterestType == InterestType.play)
            {
                next = null;
            }
            else if (_manager.PointOfInterest.InterestType == InterestType.rest)
            {
                next = new ActionState(DogState.Rest, _manager.PointOfInterest.InterestTime, _controller, _manager);
            }
            
            _manager.PointOfInterest.canBeUsed = false;
            return new RunningToState(5, _manager.PointOfInterest.transform, _controller, _manager, next);
        }

        return new WaitingState(null, _controller,_manager, 3);
    }

    public override void onStateExit()
    {
    }

   
}
