using UnityEngine;
using TMPro;
using System.Collections;

public class ScoringSystem : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    private float currentScore = 0f;
    private float targetScore = 0f;
    public float scoreIncreaseRate = 10f;
    private int highScore;
    private GameManager gameManager;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        scoreText.text = Mathf.FloorToInt(currentScore).ToString("D6");
        highScoreText.text = highScore.ToString("D6");

        gameManager = FindObjectOfType<GameManager>();
        StartCoroutine(UpdateScore());
    }

    void Update()
    {
        if (currentScore < targetScore)
        {
            currentScore += scoreIncreaseRate * Time.deltaTime;
            scoreText.text = Mathf.FloorToInt(currentScore).ToString("D6");
        }

        if (Mathf.FloorToInt(currentScore) > highScore)
        {
            highScore = Mathf.FloorToInt(currentScore);
            highScoreText.text = highScore.ToString("D6");
            PlayerPrefs.SetInt("HighScore", highScore);
        }

        if (Mathf.FloorToInt(currentScore) >= 999999)
        {
            gameManager.TriggerMaxScoreReached();
        }
    }

    IEnumerator UpdateScore()
    {
        while (true)
        {
            targetScore += 10f;
            yield return new WaitForSeconds(1f);
        }
    }

    public void ClearHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
        highScore = 0;
        highScoreText.text = highScore.ToString("D6");
    }

    public void SaveFinalScore()
    {
        if (Mathf.FloorToInt(currentScore) > highScore)
        {
            highScore = Mathf.FloorToInt(currentScore);
            PlayerPrefs.SetInt("HighScore", highScore);
            highScoreText.text = highScore.ToString("D6");
        }
        StopCoroutine(UpdateScore());
    }
}
