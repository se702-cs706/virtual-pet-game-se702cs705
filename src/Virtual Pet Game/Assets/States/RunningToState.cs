using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningToState : IState
{
    private AgentController _controller;
    private IStateActions _manager;
    private float _maxSpeed;
    private Transform _target;

    public RunningToState(float maxSpeed, Transform target, AgentController controller, IStateActions manager)
    {
        _target = target;
        _maxSpeed = maxSpeed;
        _controller = controller;
        _manager = manager;
    }
    
    public void onStateEnter()
    {
        _controller.maxSpeed = _maxSpeed;
        _controller.target = _target;
        _controller.isMovingToTarget = true;

    }

    public IState onStateUpdate()
    {
        _controller.target = _target;

        if (!_controller.isMovingToTarget)
        {
            if (_target.position == GameObject.Find("Cube Target").transform.position)
            {

                Debug.Log(GameObject.Find("Cube Target (1)").transform);
                return new RunningToState(_maxSpeed, GameObject.Find("Cube Target (1)").transform, _controller, _manager);

            }
            else if (_target.position == GameObject.Find("Cube Target (1)").transform.position)
            {

                Debug.Log(GameObject.Find("Cube Target (4)").transform);
                return new RunningToState(_maxSpeed, GameObject.Find("Cube Target (4)").transform, _controller, _manager);

            }
            else if (_target.position == GameObject.Find("Cube Target (4)").transform.position)
            {

                Debug.Log(GameObject.Find("Cube Target (2)").transform);
                return new RunningToState(_maxSpeed, GameObject.Find("Cube Target (2)").transform, _controller, _manager);

            }
            else if (_target.position == GameObject.Find("Cube Target (2)").transform.position)
            {

                Debug.Log(GameObject.Find("Cube Target (3)").transform);
                return new RunningToState(_maxSpeed, GameObject.Find("Cube Target (3)").transform, _controller, _manager);

            }
            else if (_target.position == GameObject.Find("Cube Target (3)").transform.position)
            {

                Debug.Log(GameObject.Find("Cube Target (5)").transform);
                return new RunningToState(_maxSpeed, GameObject.Find("Cube Target (5)").transform, _controller, _manager);

            }
            else if (_target.position == GameObject.Find("Cube Target (5)").transform.position)
            {

                Debug.Log(GameObject.Find("Cube Target (6)").transform);
                return new RunningToState(_maxSpeed, GameObject.Find("Cube Target (6)").transform, _controller, _manager);

            }
            else
            {
                Debug.Log("Null Chicken");
                return new WaitingState(null, _controller, _manager);
            }
        }
        else
        {
            return null;
        }
    }

    public void onStateExit()
    {
        
    }
}
