using UnityEngine;

public class ExitPopup : MonoBehaviour {
    public GameObject exitPopup;

    public void OpenPopup() {
        exitPopup.SetActive(true);
        AudioManager.Instance.PlayPopup();
    }

    public void ClosePopup() {
        exitPopup.SetActive(false);
    }

    public void QuitGame() {
        Application.Quit();
    }
}