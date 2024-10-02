using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Button startButton;
    public Button restartButton;
    public Button clearMemoryButton;
    public TextMeshProUGUI startText;
    public TextMeshProUGUI restartText;
    public TextMeshProUGUI maxScoreReachedText;

    public static bool gameStarted = false;

    void Start()
    {
        gameStarted = false;
        PauseGameComponents();
        startButton.onClick.AddListener(StartGame);
        restartButton.onClick.AddListener(ReloadScene);
        restartButton.gameObject.SetActive(false);
        clearMemoryButton.gameObject.SetActive(false);
        restartText.gameObject.SetActive(false);
        maxScoreReachedText.gameObject.SetActive(false);
    }

    void StartGame()
    {
        gameStarted = true;
        startButton.gameObject.SetActive(false);
        startText.gameObject.SetActive(false);
        ResumeGameComponents();
    }

    public void ShowRestartUI()
    {
        gameStarted = false;
        restartButton.gameObject.SetActive(true);
        clearMemoryButton.gameObject.SetActive(true);
        restartText.gameObject.SetActive(true);
        PauseGameComponents();
    }

    void ReloadScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void TriggerMaxScoreReached()
    {
        Time.timeScale = 0f;
        maxScoreReachedText.gameObject.SetActive(true);
    }

    void PauseGameComponents()
    {
        FindObjectOfType<ScoringSystem>().enabled = false;
        FindObjectOfType<CloudSpawner>().enabled = false;
        FindObjectOfType<EnemySpawner>().enabled = false;
        FindObjectOfType<ObstacleSpawner>().enabled = false;
        FindObjectOfType<CloudMovementScript>().enabled = false;
    }

    void ResumeGameComponents()
    {
        FindObjectOfType<ScoringSystem>().enabled = true;
        FindObjectOfType<CloudSpawner>().enabled = true;
        FindObjectOfType<EnemySpawner>().enabled = true;
        FindObjectOfType<ObstacleSpawner>().enabled = true;
        FindObjectOfType<CloudMovementScript>().enabled = true;
    }
}
