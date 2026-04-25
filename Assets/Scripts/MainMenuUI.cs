using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuUI : MonoBehaviour {
    public void PlayGame() {
        StartCoroutine(LoadGameRoutine());
    }

    IEnumerator LoadGameRoutine() {
        AudioManager.Instance.PlayButton();

        yield return new WaitForSeconds(0.2f);

        SceneManager.LoadScene("Game");
    }

    public void QuitGame() {
        Application.Quit();
    }
}