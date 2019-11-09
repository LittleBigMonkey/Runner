using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject intro, gameover;

    public static GameManager instance;

    public bool isRunning => Time.timeScale > 0.0f;

    void Awake()
    {
        if (!instance)
            instance = this; //singleton
        else
            Destroy(gameObject);
    }

    void Start()
    {
        intro?.SetActive(true);
        gameover?.SetActive(false);

        Time.timeScale = 0.0f;
    }

    public void StartGame()
    {
        intro?.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void StopGame()
    {
        gameover?.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
