using UnityEngine;
using TMPro;

public class MainMenuStats : MonoBehaviour {
    public GameObject statsPopup;
    //public TMP_Text statsText;

    public TMP_Text totalGames;
    
    public TMP_Text p1Wins;
    
    public TMP_Text p2Wins;
    
    public TMP_Text draws;
    
    public TMP_Text avgTime;

    public void OpenStats() {
        float avg = StatsManager.GetAverageTime();

        //statsText.text =
        //    "Total Games: " + StatsManager.GetTotalGames() + "\n" +
        //    "Player 1 Wins: " + StatsManager.GetP1Wins() + "\n" +
        //    "Player 2 Wins: " + StatsManager.GetP2Wins() + "\n" +
        //    "Draws: " + StatsManager.GetDraws() + "\n" +
        //    "Average Time: " + avg.ToString("0.0") + " sec";

        totalGames.text = "Total Games: " + StatsManager.GetTotalGames();
        p1Wins.text = "Player 1 Wins: " + StatsManager.GetP1Wins();
        p2Wins.text = "Player 2 Wins: " + StatsManager.GetP2Wins();
        draws.text = "Draws: " + StatsManager.GetDraws();
        avgTime.text = "Avg Time: " + StatsManager.GetAverageTime().ToString("0.0") + " sec";

        statsPopup.SetActive(true);
        AudioManager.Instance.PlayPopup();
    }

    public void CloseStats() {
        statsPopup.SetActive(false);
    }
}