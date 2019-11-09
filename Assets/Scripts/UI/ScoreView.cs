using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    public TMP_Text score;

    void OnEnable()
    {
        PlayerData.ScoreChanged += OnScoreChanged;
    }

    void OnDisable()
    {
        PlayerData.ScoreChanged -= OnScoreChanged;
    }

    void OnScoreChanged(int value)
    {
        if (score) score.text = value.ToString();
    }
}