using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingState : TimedState
{
    private float _maxSpeed;
    
    public WanderingState(float maxSpeed, float time, AgentController controller, IStateActions manager) : base(time, controller, manager)
    {
        _maxSpeed = maxSpeed;
    }
    
    public override void onStateEnter()
    {
        _manager.setState(DogState.Moving);
        _controller.maxSpeed = _maxSpeed;
    }

    public override IState onTimeRunningUpdate()
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

    public override IState onTimeExpireUpdate()
    {
        if (_manager.PointOfInterest != null)
        {
            IState next = null;
            if (_manager.PointOfInterest.InterestType == InterestType.food)
            {
                next = new ActionState(DogState.Eat, _controller, _manager, _manager.PointOfInterest.InterestTime);
            }
            else if (_manager.PointOfInterest.InterestType == InterestType.play)
            {
                next = null;
            }
            else if (_manager.PointOfInterest.InterestType == InterestType.rest)
            {
                next = new ActionState(DogState.Rest, _controller, _manager, _manager.PointOfInterest.InterestTime);
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
