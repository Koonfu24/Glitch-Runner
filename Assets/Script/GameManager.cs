using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro; // Assuming TextMeshPro is used, if not we can use legacy Text

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TextMeshProUGUI scoreText; // Assign in Inspector
    public GameObject gameOverPanel; 

    private float score;
    private bool isGameOver;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Update()
    {
        if (!isGameOver)
        {
            score += Time.deltaTime;
            if(scoreText != null)
                scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();
        }

        if (isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        if(gameOverPanel != null)
            gameOverPanel.SetActive(true);
        
        // Stop the game speed
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
