using System;

public static class PlayerData
{
    private static int score;
    public static event Action<int> ScoreChanged;

    public static int Score
    {
        get { return score; }
        set
        {
            score = value;
            ScoreChanged?.Invoke(score);
        }
    }

    public static void Reset()
    {
        score = 0;
    }
}