using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isGameStarted = false;
    private bool isGameOver = false;
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        isGameStarted = false;
        isGameOver = false;
        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        if(isGameStarted) return;

        isGameStarted = true;

        UIManager.Instance.HideStartPanel();
        UIManager.Instance.HideGameOverPanel();

        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        if(isGameOver) return;

        isGameOver = true;

        Time.timeScale = 0f;

        int finalScore = ScoreManager.Instance.GetCurrentScore();
        UIManager.Instance.ShowGameOverPanel(finalScore);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        isGameStarted = false;
        isGameOver = false;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public bool IsGameStarted()
    {
        return isGameStarted;
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }
}
