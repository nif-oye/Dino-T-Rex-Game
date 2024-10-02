using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovementScript : MonoBehaviour
{
    public float speed = 1f;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
