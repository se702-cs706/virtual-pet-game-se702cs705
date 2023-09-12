using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public enum targetBehaviours
{
    None = 0,
    Move = 1,
    Throw = 2,
    Sniff = 3
}

[RequireComponent(typeof(NavMeshAgent))]
public class DogBehaviour : MonoBehaviour
{
    private double _targetPosX;
    private double _targetPosY;
    private double _targetPosZ;
    private Vector3 _target = new(0f, 0f, 0f);
    private targetBehaviours _targetType = targetBehaviours.Sniff;
    private Vector3 _position;
    private float _targetTime = -1f;
    private bool _toyThrow = false;
    private Vector3 _speed;
    private Vector3 _lastPos;
    private NavMeshAgent _agent;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        Debug.Log("Start");
        _agent.destination = _target;
        _lastPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {


        _position = transform.position;
        _speed = (_position - _lastPos) / Time.deltaTime;
        _lastPos = _position;
        Debug.Log(_speed);

        if ((Math.Abs(_target[0] - _position[0]) < 0.2 && Math.Abs(_target[2] - _position[2]) < 0.2) &&
            (_targetType == targetBehaviours.Sniff || _targetType == targetBehaviours.Throw))
        {

            if (_targetType == targetBehaviours.Sniff)
            {

                if (_targetTime < Time.time)
                {
                    Debug.Log("SNIFF SNIFF");
                    _targetTime = Time.time + 3.5f;
                }

                if (_targetTime - Time.time < 0.5f)
                {
                    pickNewAction();
                }

                if (_targetTime - Time.time > 0.5)
                {
                    transform.eulerAngles = new Vector3(customNormalDist(320f, 1f, 1f, 2.6f, -15f, 0f, _targetTime - Time.time) +
                                                        customNormalDist(320f, 1f, 1f, 1.8f, -15f, 0f, _targetTime - Time.time), 0f, 0f);
                }
            }
            else if (_targetType == targetBehaviours.Throw)
            {
                if (_targetTime < Time.time)
                {
                    Debug.Log("THROW TOY");
                    _targetTime = Time.time + 2.5f;
                }

                if (_targetTime - Time.time < 0.5f)
                {
                    pickNewAction();
                }

                if (_targetTime - Time.time > 0.5)
                {
                    transform.eulerAngles = new Vector3(customNormalDist(240f, 1f, 1f, 2f, -12.5f, 0f, _targetTime - Time.time), 0f, 0f);
                }

                if (_targetTime - Time.time < 1.9f && _targetTime - Time.time > 1.8f && _toyThrow == false)
                {

                    throwToy();

                }

            }

        }

    }

    void pickNewAction()
    {

        var action = UnityEngine.Random.Range(0f, 3f);

        if (action < 1)
        {

            Debug.Log("Chosen Action: Sniffing");
            pickTarget();
            _targetType = targetBehaviours.Sniff;
            _agent.destination = _target;


        } else if (action < 4)
        {

            Debug.Log("Chosen Action: Throw Toy");
            _target = GameObject.Find("Capsule Toy").transform.position;
            _target[2] = _target[2] + 1.5f;
            _targetType = targetBehaviours.Throw;
            _toyThrow = false;
            _agent.destination = _target;

        } else
        {

        }

    }

    void throwToy()
    {
        Rigidbody toy = GameObject.Find("Capsule Toy").GetComponent<Rigidbody>();

        Vector3 toyPos = GameObject.Find("Capsule Toy").transform.position;
        toy.AddForce(new Vector3(-toyPos[0], 7f, -toyPos[2]) * 1.5f, ForceMode.Impulse);
        _toyThrow = true;

    }

    void pickTarget()
    {

        _position = GameObject.Find("Capsule Dog").transform.position;
        Debug.Log("Current Position: " + _position);
        var x = _position[0] + UnityEngine.Random.Range(-5f,5f);
        var z = _position[2] + UnityEngine.Random.Range(-5f,5f);

        if (x > 15)
        {
            x = 15;
        }

        if (x < -15)
        {
            x = -15;
        }

        if (z > 10)
        {
            x = 10;
        }

        if (z < -20)
        {
            z = -20;
        }

        Vector3 randomPosition = new Vector3(x, _position[1], z);
        Debug.Log("Random Position: " + randomPosition[0] + ", " + randomPosition[1] + ", " + randomPosition[2]);
        _target = randomPosition;

        transform.eulerAngles = new Vector3(0f, 0f, 0f);

    }

    float moveFunc(float target, float position)
    {

        float output = (float)(Math.Pow(Math.Abs(target - position) / 7.0f, 1.0 / 7.0)) * Math.Abs(target - position) / (target - position);
        if (output == Double.NaN || Double.IsNaN(output))
        {

            output = 0f;

        }

        //Debug.Log("Target: " + target + " Position: " + position + " Output: " + output);
        return output;

    }

    float customNormalDist(float A, float B, float C, float D, float E, float F, float x)
    {

        return A / ((1f + (float) Math.Pow(Math.E, B * E * (x - D))) * (1f + (float)Math.Pow(Math.E, -1f * C * E * (x - D)))) + F;

    }
}
