using UnityEngine;

public class FreezeOnCollision : MonoBehaviour
{
    private bool isGameFrozen = false;
    private ScoringSystem scoringSystem;
    private GameManager gameManager;

    void Start()
    {
        scoringSystem = FindObjectOfType<ScoringSystem>();
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") && !isGameFrozen)
        {
            SaveScore();
            FreezeGame();
        }
    }

    void FreezeGame()
    {
        Time.timeScale = 0f;
        isGameFrozen = true;

        if (gameManager != null)
        {
            gameManager.ShowRestartUI();
        }
    }

    void SaveScore()
    {
        if (scoringSystem != null)
        {
            scoringSystem.SaveFinalScore();
        }
    }
}
