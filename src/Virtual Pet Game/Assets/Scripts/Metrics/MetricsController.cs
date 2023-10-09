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

    public FileData fileData;


    public void SetUser(User newUser)
    {
        if (currentUser != null)
        {
            SaveAll();
            ResetAll();
        }

        currentUser = newUser;
    }

    public void AddInteraction(InteractionEvent interactionEvent)
    {
        interactionEvents.Add(interactionEvent);
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
        fileData = new FileData(currentUser, interactionEvents, playTimes, fixationTimes);
        string dataJSON = JsonUtility.ToJson(fileData, true);
        string path = Application.persistentDataPath + "/" + currentUser.id.ToString() + ".json";
        System.IO.File.WriteAllText(path, dataJSON);
        Debug.Log("Writing log file to: " + path);
    }

    public void LogToDatabase()
    {

    }
}
