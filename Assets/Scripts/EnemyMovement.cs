using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float enemyMovementSpeed = 8f;

    void FixedUpdate()
    {
        transform.Translate(Vector3.left * Time.deltaTime * enemyMovementSpeed);
    }
}
