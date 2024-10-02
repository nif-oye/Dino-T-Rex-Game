using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float obstacleMovementSpeed = 7f;
    public float gameTime;

    void FixedUpdate()
    {
        gameTime = Time.timeSinceLevelLoad;
        if (gameTime > 30f)
        {
            obstacleMovementSpeed = 9f;
        }
        if (gameTime > 60f)
        {
            obstacleMovementSpeed = 12f;
        }
        else if (gameTime > 180f)
        {
            obstacleMovementSpeed = 17f;
        }
        transform.Translate(Vector3.left * Time.deltaTime * obstacleMovementSpeed);
    }
}
