using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusMovementScript : MonoBehaviour
{
    public float cactusMovementSpeed = 7f;
    public float gameTime;

    void FixedUpdate()
    {
        gameTime = Time.timeSinceLevelLoad;
        if (gameTime > 30f)
        {
            cactusMovementSpeed = 9f;
        }
        if (gameTime > 60f)
        {
            cactusMovementSpeed = 12f;
        }
        else if (gameTime > 180f)
        {
            cactusMovementSpeed = 17f;
        }
        transform.Translate(Vector3.left * Time.deltaTime * cactusMovementSpeed);
    }
}
