using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class RunningToState : GoalState
{
    private float _maxSpeed;
    private Vector3 _target;

    public RunningToState(
        float maxSpeed, 
        Vector3 target, 
        AgentController controller, IStateActions manager, [CanBeNull] IState next = null) : 
        base(DogState.Moving, controller, manager, next)
    {
        _maxSpeed = maxSpeed;
        _target = target;
    }
    
    public override void onStateEnterChild()
    {
        _controller.maxSpeed = _maxSpeed;
        _controller.target = _target;
        _controller.isMovingToTarget = true;

    }

    public override IState onStateDuringUpdate()
    {
        _controller.target = _target;

        if (!_controller.isMovingToTarget)
        {
            if (_target == GameObject.Find("Cube Target").transform.position)
            {

                Debug.Log(GameObject.Find("Cube Target (1)").transform);
                return new RunningToState(_maxSpeed, GameObject.Find("Cube Target (1)").transform.position, _controller, _manager);

            }
            else if (_target == GameObject.Find("Cube Target (1)").transform.position)
            {

                Debug.Log(GameObject.Find("Cube Target (4)").transform);
                return new RunningToState(_maxSpeed, GameObject.Find("Cube Target (4)").transform.position, _controller, _manager);

            }
            else if (_target == GameObject.Find("Cube Target (4)").transform.position)
            {

                Debug.Log(GameObject.Find("Cube Target (2)").transform);
                return new RunningToState(_maxSpeed, GameObject.Find("Cube Target (2)").transform.position, _controller, _manager);

            }
            else if (_target == GameObject.Find("Cube Target (2)").transform.position)
            {

                Debug.Log(GameObject.Find("Cube Target (3)").transform);
                return new RunningToState(_maxSpeed, GameObject.Find("Cube Target (3)").transform.position, _controller, _manager);

            }
            else if (_target == GameObject.Find("Cube Target (3)").transform.position)
            {

                Debug.Log(GameObject.Find("Cube Target (5)").transform);
                return new RunningToState(_maxSpeed, GameObject.Find("Cube Target (5)").transform.position, _controller, _manager);

            }
            else if (_target == GameObject.Find("Cube Target (5)").transform.position)
            {

                Debug.Log(GameObject.Find("Cube Target (6)").transform);
                return new RunningToState(_maxSpeed, GameObject.Find("Cube Target (6)").transform.position, _controller, _manager);

            }
            else
            {
                Debug.Log("Null Chicken");
                return new WaitingState(4f, _controller, _manager);
            }
        }
        else
        {

            return null;

        }
    }

    public override bool goalCondition()
    {
        return !_controller.isMovingToTarget;
    }

    public override IState onGoalReached()
    {
        if (_next != null)
        {
            return _next;
        }
        return new WaitingState(5, _controller, _manager);
    }

    public override void onStateExit()
    {
        
    }

}
