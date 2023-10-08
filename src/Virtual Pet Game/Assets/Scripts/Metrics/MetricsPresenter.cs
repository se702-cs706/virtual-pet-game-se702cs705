using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetricsPresenter : MonoBehaviour
{
    [SerializeField] MetricsController controller;

    public void LogInfo(string info)
    {
        Debug.Log(info);
    }


    public void SetDogModelType(DogModelType model)
    {
        controller.model = model;
    }

    public void CreateUserId()
    {
        controller.SetUser(new User());
    }
}
