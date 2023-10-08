using System;
using System.Collections;
using System.Collections.Generic;
using Interactable;
using UnityEngine;

public class BowlController : MonoBehaviour
{
    private float _bowlFill = 1;
    [SerializeField] private GameObject food;
    [SerializeField] private float lower = 0;
    private Vector3 initialPos;

    private void Start()
    {
        initialPos = food.transform.position;
    }


    private void Update()
    {

    }

    /// <summary>
    /// Change the displayed fill amount of the bowl.
    /// Also updates the bowl fill parameter.
    /// </summary>
    /// <param name="fill">percentage of food</param>
    public void ChangeFill(float fill)
    {
        _bowlFill = Math.Clamp(fill, 0, 1);
         food.transform.position = new Vector3(initialPos.x, initialPos.y - lower + (_bowlFill*lower) , initialPos.z);
    }

    public float getBowlFill()
    {
        return _bowlFill;
    }


    // TODO: bowlState will change how the bowl looks (filled, empty)
    // Also will change to point of interest for dog?
}