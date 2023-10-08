using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetricsPresenter : MonoBehaviour
{
    [SerializeField] MetricsController controller;

    ModelPlayTime currentPlayTime;
    ModelFixationTime currentFixation;

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


    public void StartPlayTime()
    {
        currentPlayTime = new(DateTime.Now.ToString(), controller.currentUser.id, controller.model);
    }

    public void StopPlayTime()
    {
        TimeSpan timeSpan = DateTime.Now - DateTime.Parse(currentPlayTime.timestamp);
        currentPlayTime.playTime = (float)timeSpan.TotalMilliseconds;

        Debug.Log(currentPlayTime);

        controller.AddPlayTime(currentPlayTime);
    }

    /// <summary>
    /// Called when swapping from one model to the other. Only used in pause menu.
    /// </summary>
    public void SwitchModelPlayTime()
    {
        // Don't record new playtime if switching between the same model.
        if (controller.model == currentPlayTime.model) return;

        StopPlayTime();
        StartPlayTime();
    }



    // FIXME: duplicate of PlayTime, maybe create an abstract class for generic durations?
    public void StartFixation()
    {
        currentFixation = new(DateTime.Now.ToString(), controller.currentUser.id, controller.model);
    }

    public void StopFixation()
    {
        TimeSpan timeSpan = DateTime.Now - DateTime.Parse(currentFixation.timestamp);
        currentFixation.fixationTime = (float)timeSpan.TotalMilliseconds;

        Debug.Log(currentFixation);

        controller.AddFixation(currentFixation);
    }
}
