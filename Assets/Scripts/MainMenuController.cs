using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Correct way to include the SceneManagement namespace

public class MainMenuController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene"); // Replace "GameScene" with your game scene name
    }

    public void OpenOptions()
    {
        // Code to open options menu
    }

    public void OpenCredits()
    {
        // Code to open credits menu
    }

    public void OpenLevelSelect()
    {
        // Code to open level selection menu
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
