using UnityEngine;

public static class StatsManager {
    public static void AddGame(float duration, int winner) {
        int totalGames = PlayerPrefs.GetInt("TotalGames", 0);
        PlayerPrefs.SetInt("TotalGames", totalGames + 1);

        float totalTime = PlayerPrefs.GetFloat("TotalTime", 0f);
        PlayerPrefs.SetFloat("TotalTime", totalTime + duration);

        if (winner == 1) {
            int p1Wins = PlayerPrefs.GetInt("P1Wins", 0);
            PlayerPrefs.SetInt("P1Wins", p1Wins + 1);
        } else if (winner == 2) {
            int p2Wins = PlayerPrefs.GetInt("P2Wins", 0);
            PlayerPrefs.SetInt("P2Wins", p2Wins + 1);
        } else {
            int draws = PlayerPrefs.GetInt("Draws", 0);
            PlayerPrefs.SetInt("Draws", draws + 1);
        }

        PlayerPrefs.Save();
    }

    public static int GetTotalGames() {
        return PlayerPrefs.GetInt("TotalGames", 0);
    }

    public static int GetP1Wins() {
        return PlayerPrefs.GetInt("P1Wins", 0);
    }

    public static int GetP2Wins() {
        return PlayerPrefs.GetInt("P2Wins", 0);
    }

    public static int GetDraws() {
        return PlayerPrefs.GetInt("Draws", 0);
    }

    public static float GetAverageTime() {
        int totalGames = GetTotalGames();

        if (totalGames == 0)
            return 0f;

        float totalTime = PlayerPrefs.GetFloat("TotalTime", 0f);

        return totalTime / totalGames;
    }
}