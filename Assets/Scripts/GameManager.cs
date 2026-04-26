using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;

    public bool playerOneTurn = true;

    private string[] board = new string[9];
    
    private bool gameOver = false;
    
    private int moveCount = 0;

    public Sprite x0_red;

    public Sprite o0_black;

    public Sprite x1_blue;
    
    public Sprite o1_yellow;

    public Sprite x2_green;
    
    public Sprite o2_violet;

    private string winMessage;


    private int[,] winPatterns = {
        {0,1,2},
        {3,4,5},
        {6,7,8},
        {0,3,6},
        {1,4,7},
        {2,5,8},
        {0,4,8},
        {2,4,6}
    };

    private void Awake()
    {
        Instance = this;
    }

    public string GetCurrentMark()
    {
        return playerOneTurn ? "X" : "O";
    }

    public bool IsGameOver()
    {
        return gameOver;
    }

    public void MakeMove(int index) {
        if (gameOver) return;

        board[index] = GetCurrentMark();
        moveCount++;

        if (CheckWin()) {
            gameOver = true;

            int winner = playerOneTurn ? 1 : 2;

            StatsManager.AddGame(UIManager.Instance.GetCurrentTime(), winner);

            StrikeEffect effect = FindObjectOfType<StrikeEffect>();

            effect.PlayEffect();
           
            winMessage = winner == 1 ? "Player 1 Wins!" : "Player 2 Wins!";
            // UIManager.Instance.ShowResult(message);
            //UIManager.Instance.ShowResult(message);
            Invoke(nameof(ShowWinPopup), 0.5f);
            Invoke(nameof(PlayWinSound), 0.05f);

            return;
        }

        if (moveCount >= 9)
        {
            gameOver = true;

            StatsManager.AddGame(UIManager.Instance.GetCurrentTime(), 0);

            UIManager.Instance.ShowResult("Draw!");

            return;
        }

        playerOneTurn = !playerOneTurn;
    }

    void ShowWinPopup() {
        UIManager.Instance.ShowResult(winMessage);
    }

    void PlayWinSound() {
        AudioManager.Instance.PlayWin();
    }

    bool CheckWin() {
        for (int i = 0; i < 8; i++) {
            int a = winPatterns[i, 0];
            int b = winPatterns[i, 1];
            int c = winPatterns[i, 2];

            if (!string.IsNullOrEmpty(board[a]) &&
                board[a] == board[b] &&
                board[b] == board[c]) {

                return true;
            }
        }

        return false;
    }

    public Sprite GetCurrentSprite() {
        int theme = PlayerPrefs.GetInt("ThemeIndex", 0);

        if (playerOneTurn == true) {
            if (theme == 0) return x0_red;
            if (theme == 1) return x1_blue;
            if (theme == 2) return x2_green;
            return x0_red;
        } else {
            if (theme == 0) return o0_black;
            if (theme == 1) return o1_yellow;
            if (theme == 2) return o2_violet;
            return o0_black;
        }
    }
}