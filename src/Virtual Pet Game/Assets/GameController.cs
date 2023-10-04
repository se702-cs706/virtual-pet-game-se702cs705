using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject gameScene;
    public GameObject pauseMenu;
    public GameObject mainMenu;
    public bool isGamePaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) // Use your desired key
        {
            if (isGamePaused) ResumeGame(); else PauseGame();
        }
    }

    public void RestartGame()
    {
        // Reload the current scene to restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void PauseGame()
    {
        Debug.Log("Paused");
        isGamePaused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;  // Pause game logic
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ResumeGame()
    {
        isGamePaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;  // Resume game logic
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ReturnToMainMenu()
    {
        gameScene.SetActive(false);
        pauseMenu.SetActive(false);
        mainMenu.SetActive(true);
        // Any additional cleanup before returning to the main menu.
    }


}

