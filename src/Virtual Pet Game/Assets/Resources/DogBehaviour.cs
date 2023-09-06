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

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        pickTarget();

    }

    // Update is called once per frame
    void Update()
    {

        move();

    }

    void move()
    {

        if (Math.Round(Time.time) % 2 <= 0)
        {

            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        }

    }

    void pickTarget()
    {

        var position = GameObject.Find("Capsule Dog").transform.position;
        Debug.Log("Current Position: " + position);
        var x = UnityEngine.Random.Range(-5f,5f);
        Debug.Log(x);
        transform.eulerAngles = new Vector3(0f, 0f, 0f);

    }
}
