using TMPro;
using UnityEngine;

public class GameOverView : MonoBehaviour
{
    public TMP_Text score;

    void OnEnable()
    {
        if (score) score.text = PlayerData.Score.ToString();
    }
}
