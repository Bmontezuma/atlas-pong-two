using UnityEngine;
using UnityEngine.UI;

public class OptionsMenuController : MonoBehaviour
{
    public Slider masterVolumeSlider;
    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;
    public Toggle enableAIToggle;

    void Start()
    {
        // Initialize sliders and toggles with saved values or defaults
        masterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume", 1f);
        musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);
        sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1f);
        enableAIToggle.isOn = PlayerPrefs.GetInt("EnableAI", 1) == 1;
    }

    public void SetMasterVolume(float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("MasterVolume", volume);
    }

    public void SetMusicVolume(float volume)
    {
        // Set the music volume in your audio manager
        // AudioManager.Instance.SetMusicVolume(volume);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        // Set the SFX volume in your audio manager
        // AudioManager.Instance.SetSFXVolume(volume);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    public void ToggleAI(bool isEnabled)
    {
        PlayerPrefs.SetInt("EnableAI", isEnabled ? 1 : 0);
        // Handle enabling or disabling AI in your game logic
    }

    public void ApplyChanges()
    {
        // Apply changes (already saved in PlayerPrefs in this case)
        // You can add additional logic if needed
    }

    public void BackToMainMenu()
    {
        // Load main menu scene or close options menu
        // SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void OpenKeyBindings()
    {
        // Logic to open key bindings menu
    }
}
