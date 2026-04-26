using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public static UIManager Instance;

    public GameObject resultPopup;
    
    public TMP_Text resultText;

    private float gameTimer = 0f;
    
    private bool timerRunning = true;

    private int p1Moves = 0;
    
    private int p2Moves = 0;

    public TMP_Text timerText;

    public TMP_Text p1MovesText;
    
    public TMP_Text p2MovesText;


    private void Start() {
        resultPopup.SetActive(false);

        //if (Screen.width > Screen.height)
        //{
        //    hudPanel.sizeDelta = new Vector2(0, 70);
        //}
        //else
        //{
        //    hudPanel.sizeDelta = new Vector2(0, 120);
        //}

    }

    private void Awake() {
        Instance = this;
    }

    private void Update() {
        if (timerRunning) {

            gameTimer += Time.deltaTime;

            int minutes = Mathf.FloorToInt(gameTimer / 60);
            int seconds = Mathf.FloorToInt(gameTimer % 60);

            timerText.text = "Time: " + minutes.ToString("00") + ":" + seconds.ToString("00");
        }
    }

    //public void ShowResult(string message) {
    //    resultText.text = message;
    //    resultPopup.SetActive(true);
    //}

    public void ShowResult(string message) {
        timerRunning = false;
        resultText.text = message;
        resultPopup.SetActive(true);
    }

    public void RetryGame() {
        Debug.Log("Retrying game...");
        SceneManager.LoadScene("Game");
    }

    public void ExitToMenu() {
        SceneManager.LoadScene("MainMenu");
    }

    public void RegisterMove(bool playerOneTurn) {
        if (playerOneTurn)
            p1Moves++;
        else
            p2Moves++;

        p1MovesText.text = "P1 Moves: " + p1Moves;
        p2MovesText.text = "P2 Moves: " + p2Moves;
    }

    public float GetCurrentTime() {
        return gameTimer;
    }
}