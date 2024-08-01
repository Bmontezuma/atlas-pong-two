using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // The UI panel for the pause menu
    public static bool GameIsPaused = false; // Tracks whether the game is currently paused

    void Update()
    {
        // Check if the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Toggle between pause and resume states
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Debug.Log("Resuming game");
        pauseMenuUI.SetActive(false); // Hide the pause menu UI
        Time.timeScale = 1f; // Resume game time
        GameIsPaused = false; // Update the paused state
    }

    void Pause()
    {
        Debug.Log("Pausing game");
        pauseMenuUI.SetActive(true); // Show the pause menu UI
        Time.timeScale = 0f; // Pause game time
        GameIsPaused = true; // Update the paused state
    }

    public void LoadMenu()
    {
        Debug.Log("Loading main menu");
        Time.timeScale = 1f; // Ensure game time is resumed before switching scenes
        SceneManager.LoadScene("MainMenu"); // Load the main menu scene
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit(); // Quit the application
    }

    public void LoadOptions()
    {
        Debug.Log("Loading options menu");
        // Implement your options menu logic here
        // For example, load an Options scene or show an Options panel
    }
}
