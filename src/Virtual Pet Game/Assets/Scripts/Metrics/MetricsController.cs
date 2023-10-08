using System;
using UnityEngine;
using System.Collections.Generic;

public class MetricsController : MonoBehaviour
{
    public User currentUser { private set; get; }
    public DogModelType model;


    public List<InteractionEvent> interactionEvents { private set; get; }
    public List<ModelFixationTime> fixationTimes { private set; get; }
    public List<ModelPlayTime> playTimes { private set; get; }

    ModelFixationTime currentFixation;

    public void SetUser(User newUser)
    {
        if (currentUser != null)
        {
            SaveAll();
            ResetAll();
        }

        currentUser = newUser;
    }


    public void StartFixation()
    {
        currentFixation = new(DateTime.Now, currentUser.id, model);
    }

    public void StopFixation()
    {
        TimeSpan timeSpan = DateTime.Now - currentFixation.timestamp;

        // https://stackoverflow.com/questions/6104693/c-sharp-is-it-possible-to-convert-datetime-format-to-integer-or-float
        currentFixation.fixationTime = (float)timeSpan.TotalMilliseconds;

        Debug.Log(currentFixation.fixationTime);

        fixationTimes.Add(currentFixation);
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
