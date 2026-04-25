using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ThemeSelector : MonoBehaviour {
    public GameObject themePopup;
    public TMP_Dropdown themeDropdown;

    public void OpenPopup() {
        themePopup.SetActive(true);
        AudioManager.Instance.PlayPopup();
    }

    public void ClosePopup() {
        themePopup.SetActive(false);
    }

    public void StartGame() {
        int selectedTheme = themeDropdown.value;

        PlayerPrefs.SetInt("ThemeIndex", selectedTheme);
        PlayerPrefs.Save();

        SceneManager.LoadScene("Game");
    }
}