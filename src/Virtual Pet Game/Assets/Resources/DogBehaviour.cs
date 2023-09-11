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

public class DogBehaviour : MonoBehaviour
{
    private double targetPosX;
    private double targetPosY;
    private double targetPosZ;
    private Vector3 target = new Vector3(0f, 0f, 0f);
    private targetBehaviours targetType = targetBehaviours.Sniff;
    private Vector3 position;
    private float targetTime = -1f;
    private Boolean toyThrow = false;
    private Vector3 speed;
    private Vector3 lastPos;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Debug.Log("Start");
        agent.destination = target;
        lastPos = GameObject.Find("Capsule Dog").transform.position;

    }

    // Update is called once per frame
    void Update()
    {


        position = GameObject.Find("Capsule Dog").transform.position;
        speed = (position - lastPos) / Time.deltaTime;
        lastPos = position;
        Debug.Log(speed);

        if ((Math.Abs(target[0] - position[0]) < 0.2 && Math.Abs(target[2] - position[2]) < 0.2) &&
            (targetType == targetBehaviours.Sniff || targetType == targetBehaviours.Throw))
        {

            if (targetType == targetBehaviours.Sniff)
            {

                if (targetTime < Time.time)
                {

                    Debug.Log("SNIFF SNIFF");
                    targetTime = Time.time + 3.5f;

                }

                if (targetTime - Time.time < 0.5f)
                {

                    pickNewAction();

                }

                if (targetTime - Time.time > 0.5)
                {

                    transform.eulerAngles = new Vector3(customNormalDist(320f, 1f, 1f, 2.6f, -15f, 0f, targetTime - Time.time) +
                        customNormalDist(320f, 1f, 1f, 1.8f, -15f, 0f, targetTime - Time.time), 0f, 0f);

                }

            }
            else if (targetType == targetBehaviours.Throw)
            {

                if (targetTime < Time.time)
                {

                    Debug.Log("THROW TOY");
                    targetTime = Time.time + 2.5f;

                }

                if (targetTime - Time.time < 0.5f)
                {

                    pickNewAction();

                }

                if (targetTime - Time.time > 0.5)
                {

                    transform.eulerAngles = new Vector3(customNormalDist(240f, 1f, 1f, 2f, -12.5f, 0f, targetTime - Time.time), 0f, 0f);

                }

                if (targetTime - Time.time < 1.9f && targetTime - Time.time > 1.8f && toyThrow == false)
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
            targetType = targetBehaviours.Sniff;
            agent.destination = target;


        } else if (action < 4)
        {

            Debug.Log("Chosen Action: Throw Toy");
            target = GameObject.Find("Capsule Toy").transform.position;
            target[2] = target[2] + 1.5f;
            targetType = targetBehaviours.Throw;
            toyThrow = false;
            agent.destination = target;

        } else
        {

        }

    }

    void throwToy()
    {
        Rigidbody toy = GameObject.Find("Capsule Toy").GetComponent<Rigidbody>();

        Vector3 toyPos = GameObject.Find("Capsule Toy").transform.position;
        toy.AddForce(new Vector3(-toyPos[0], 7f, -toyPos[2]) * 1.5f, ForceMode.Impulse);
        toyThrow = true;

    }

    void pickTarget()
    {

        position = GameObject.Find("Capsule Dog").transform.position;
        Debug.Log("Current Position: " + position);
        var x = position[0] + UnityEngine.Random.Range(-5f,5f);
        var z = position[2] + UnityEngine.Random.Range(-5f,5f);

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

        Vector3 randomPosition = new Vector3(x, position[1], z);
        Debug.Log("Random Position: " + randomPosition[0] + ", " + randomPosition[1] + ", " + randomPosition[2]);
        target = randomPosition;

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
