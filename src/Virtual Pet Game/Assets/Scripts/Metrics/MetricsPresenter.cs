using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetricsPresenter : MonoBehaviour
{
    [SerializeField] private MetricsController controller;

    private ModelPlayTime _currentPlayTime;
    private ModelFixationTime _currentFixation;
    private bool _isFixated = false;

    public void SetDogModelType(DogModelType model)
    {
        controller.model = model;
    }

    public void CreateUserId()
    {
        controller.SetUser(new User());
    }


    public void LogInteraction(string interactionName)
    {
        InteractionEvent interactionEvent = new InteractionEvent(DateTime.Now.ToString(), controller.currentUser.id, interactionName);

        Debug.Log(interactionEvent);

        controller.AddInteraction(interactionEvent);
    }

    public void StartGameMetrics()
    {
        CreateUserId();
        StartPlayTime();
    }

    public void StopGameMetrics()
    {
        StopPlayTime();
        controller.LogToFile();
    }


    public void StartPlayTime()
    {
        _currentPlayTime = new ModelPlayTime(DateTime.Now.ToString(), controller.currentUser.id, controller.model);
    }

    public void StopPlayTime()
    {
        var timeSpan = DateTime.Now - DateTime.Parse(_currentPlayTime.timestamp);
        _currentPlayTime.playTime = (float)timeSpan.TotalMilliseconds;

        Debug.Log(_currentPlayTime);

        controller.AddPlayTime(_currentPlayTime);
    }

    /// <summary>
    /// Called when swapping from one model to the other. Only used in pause menu.
    /// </summary>
    public void SwitchModelPlayTime()
    {
        // Don't record new playtime if switching between the same model.
        if (controller.model == _currentPlayTime.model) return;

        StopPlayTime();
        StartPlayTime();
    }



    // FIXME: duplicate of PlayTime, maybe create an abstract class for generic durations?
    public void StartFixation()
    {
        _currentFixation = new ModelFixationTime(DateTime.Now.ToString(), controller.currentUser.id, controller.model);
        Debug.Log("Started fixation");
        _isFixated = true;
    }

    public void StopFixation()
    {
        var timeSpan = DateTime.Now - DateTime.Parse(_currentFixation.timestamp);
        _currentFixation.fixationTime = (float)timeSpan.TotalMilliseconds;

        Debug.Log(_currentFixation);

        controller.AddFixation(_currentFixation);
        _isFixated = false;
        Debug.Log("Stopped fixation");
    }

    public bool getIsFixated()
    {
        return _isFixated;
    }
}
