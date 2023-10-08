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
    /// if fill parameter changed, food moves up
    /// </summary>
    /// <param name="fill">percentage of food</param>
    public void ChangeFill(float fill)
    {
        _bowlFill = fill;
         food.transform.position = new Vector3(0, initialPos.y - lower + (fill*lower) , 0);
    }

    public float getBowlFill()
    {
        return _bowlFill;
    }


    // TODO: bowlState will change how the bowl looks (filled, empty)
    // Also will change to point of interest for dog?
}