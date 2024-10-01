using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeOnCollision : MonoBehaviour
{
    private bool isGameFrozen = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") && !isGameFrozen)
        {
            FreezeGame();
        }
    }

    void FreezeGame()
    {
        Time.timeScale = 0f;
        isGameFrozen = true;
    }
}
