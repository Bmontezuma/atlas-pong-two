using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void StartGame()
    {
        // Load the game scene
        SceneManager.LoadScene("Start");
    }

    public void OpenLevelSelect()
    {
        // Load the level select scene
        SceneManager.LoadScene("Level");
    }

    public void OpenCredits()
    {
        // Load the credits scene
        SceneManager.LoadScene("Credits");
    }

    public void OpenOptions()
    {
        // Load the options menu
        SceneManager.LoadScene("Options");
    }

    public void ExitGame()
    {
        // Exit the game
        Application.Quit();
    }
}
