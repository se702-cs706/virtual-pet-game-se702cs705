using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public int currentMode = 1;  //mode 1: Practice, mode 2: Study
    public GameObject selectModel;

    public void PlayGame()
    {
        //SceneManager.LoadSceneAsync(1);
        if (currentMode == 2)
        {  
            selectModel.SetActive(true);
        }
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
