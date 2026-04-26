using Unity.VisualScripting;
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
        // I did not find how to make this work. Application.Quit() freezes the app
        // might just close popup and let user close the app manually
        ClosePopup();
        Application.Quit();
        Debug.Log("Quit Game");
    }
}