using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour {
    public GameObject settingsPopup;

    public Toggle musicToggle;
    public Toggle sfxToggle;

    private void Start() {
        LoadSettings();
    }

    public void OpenSettings() {
        LoadSettings();
        settingsPopup.SetActive(true);
        AudioManager.Instance.PlayPopup();
    }

    public void CloseSettings() {
        settingsPopup.SetActive(false);
    }

    public void ToggleMusic() {

        bool isOn = musicToggle.isOn;

        PlayerPrefs.SetInt("MusicOn", isOn ? 1 : 0);
        PlayerPrefs.Save();
        AudioManager.Instance.ApplySettings();

        Debug.Log("Music changed to: " + isOn);
    }

    public void ToggleSFX() {
        bool isOn = sfxToggle.isOn;

        PlayerPrefs.SetInt("SFXOn", isOn ? 1 : 0);
        PlayerPrefs.Save();
        AudioManager.Instance.ApplySettings();

        Debug.Log("SFX changed to: " + isOn);
    }

    void LoadSettings() {
        musicToggle.SetIsOnWithoutNotify(PlayerPrefs.GetInt("MusicOn", 1) == 1);
        sfxToggle.SetIsOnWithoutNotify(PlayerPrefs.GetInt("SFXOn", 1) == 1);
    }
}