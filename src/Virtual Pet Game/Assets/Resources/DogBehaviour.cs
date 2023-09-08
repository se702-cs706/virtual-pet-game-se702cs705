using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DogBehaviour : MonoBehaviour
{
    private double targetPosX;
    private double targetPosY;
    private double targetPosZ;
    private int moveSpeed = 2;
    private float[] target = {0f, 0f, 0f};
    private Vector3 position;
    private float targetTime;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");

    }

    // Update is called once per frame
    void Update()
    {

        position = GameObject.Find("Capsule Dog").transform.position;

        if (Math.Abs(target[0] - position[0]) > 0.2 || Math.Abs(target[2] - position[2]) > 0.2)
        {

            move();

        } else
        {

            if (targetTime < Time.time)
            {

                Debug.Log("SNIFF SNIFF");
                targetTime = Time.time + 3.5f;

            }

            if (targetTime - Time.time < 0.5f)
            {

                pickTarget();

            }

            if (targetTime - Time.time > 0.5)
            {

                transform.eulerAngles = new Vector3(customNormalDist(320f, 1f, 1f, 2.6f, -15f, 0f, targetTime - Time.time) +
                    customNormalDist(320f, 1f, 1f, 1.8f, -15f, 0f, targetTime - Time.time), 0f, 0f);

            }

        }

    }

    void move()
    {

        transform.Translate(new Vector3(moveFunc(target[0], position[0]), 0, moveFunc(target[2], position[2])) * moveSpeed * Time.deltaTime);

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

        float[] randomPosition = {x, position[1], z};
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
