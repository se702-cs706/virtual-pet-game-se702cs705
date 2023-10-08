using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MetricsTracker
{

    public int currentMode = 1;  //mode 1: Practice, mode 2: Study
    public GameObject selectModel;
    public GameObject MainSettings;
    public GameObject GamePlay;

    public static event Action GameStart;

    public void PlayGame()
    {
        //SceneManager.LoadSceneAsync(1);

        if (currentMode == 2)
        {  
            selectModel.SetActive(true);
        }
        else
        {
            GamePlay.SetActive(true);
            MainSettings.SetActive(false);
        }

        presenter.LogInfo("Start game.");
    }

    public void SetUserMode(int userInput)
    {
        currentMode = userInput;
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
