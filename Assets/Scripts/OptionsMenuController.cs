using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class OptionsMenuController : MonoBehaviour
{
    public Slider masterVolumeSlider;
    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;
    public Toggle aiToggle;

    private void Start()
    {
        // Load saved settings
        masterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume", 1f);
        musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);
        sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1f);
        aiToggle.isOn = PlayerPrefs.GetInt("AIEnabled", 1) == 1;
    }

    public void ApplySettings()
    {
        // Save settings
        PlayerPrefs.SetFloat("MasterVolume", masterVolumeSlider.value);
        PlayerPrefs.SetFloat("MusicVolume", musicVolumeSlider.value);
        PlayerPrefs.SetFloat("SFXVolume", sfxVolumeSlider.value);
        PlayerPrefs.SetInt("AIEnabled", aiToggle.isOn ? 1 : 0);

        // Apply settings in-game (e.g., update audio mixer, etc.)
    }

    public void Back()
    {
        // Logic to go back to the previous menu
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void OpenKeyBindings()
    {
        // Logic to open key bindings menu
    }
}
