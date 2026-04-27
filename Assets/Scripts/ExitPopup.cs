using Unity.VisualScripting;
using UnityEngine;
using static System.Net.WebRequestMethods;

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
        //Application.OpenURL("https://play.unity.com/en/games/3b567a01-308e-48b9-9222-e71b57ea26a3/tic-tac-toe");
        //Application.ExternalEval("window.open('" + "https://play.unity.com/en/games/3b567a01-308e-48b9-9222-e71b57ea26a3/tic-tac-toe" + "','_self')");
        //Debug.Log("Quit Game");
    }
}