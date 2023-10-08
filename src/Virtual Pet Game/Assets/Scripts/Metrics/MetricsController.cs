using System;
using UnityEngine;
using System.Collections.Generic;

public class MetricsController : MonoBehaviour
{
    public User currentUser { private set; get; }
    public DogModelType model;

    public List<InteractionEvent> interactionEvents { private set; get; } = new();
    public List<ModelPlayTime> playTimes { private set; get; } = new();
    public List<ModelFixationTime> fixationTimes { private set; get; } = new();


    public void SetUser(User newUser)
    {
        if (currentUser != null)
        {
            SaveAll();
            ResetAll();
        }

        currentUser = newUser;
    }


    public void AddPlayTime(ModelPlayTime playTime)
    {
        playTimes.Add(playTime);
    }

    public void AddFixation(ModelFixationTime fixationTime)
    {
        fixationTimes.Add(fixationTime);
    }



    /// <summary>
    /// Saves all the current user information.
    /// </summary>
    public void SaveAll()
    {

    }

    /// <summary>
    /// Called when quitting from in-game.
    /// </summary>
    public void ResetAll()
    {

    }

    public void LogToFile()
    {

    }

    public void LogToDatabase()
    {

    }
}
