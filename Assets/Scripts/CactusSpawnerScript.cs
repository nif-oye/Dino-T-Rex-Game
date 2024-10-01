using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusSpawnerScript : MonoBehaviour
{
    public GameObject cactusPrefab;
    public float minSpawnRate = 1f;
    public float maxSpawnRate = 3f;
    public float timeSinceLastSpawn;
    public int poolSize = 5;
    public int maxPoolSize = 5;

    private List<GameObject> cactusPool;
    private float spawnRate;

    void Start()
    {
        cactusPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(cactusPrefab);
            obj.SetActive(false);
            cactusPool.Add(obj);
        }
        spawnRate = Random.Range(minSpawnRate, maxSpawnRate);
    }

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= spawnRate)
        {
            SpawnCactus();
            timeSinceLastSpawn = 0;  
            spawnRate = Random.Range(minSpawnRate, maxSpawnRate);
        }
        
        AdjustSpawnRate();
    }

    void SpawnCactus()
    {
        for (int i = 0; i < cactusPool.Count; i++)
        {
            if (!cactusPool[i].activeInHierarchy)
            {
                cactusPool[i].transform.position = transform.position;
                cactusPool[i].SetActive(true);
                return;
            }
        }

        if (cactusPool.Count < maxPoolSize)
        {
            GameObject newCactus = Instantiate(cactusPrefab, transform.position, Quaternion.identity);
            cactusPool.Add(newCactus);
        }
        else
        {
            cactusPool[0].transform.position = transform.position;
            cactusPool[0].SetActive(true);
            cactusPool.Add(cactusPool[0]);
            cactusPool.RemoveAt(0);
        }
    }

    void AdjustSpawnRate()
    {
        float gameTime = Time.timeSinceLevelLoad;
        
        if (gameTime > 30f)  
        {
            minSpawnRate = 0.8f;
            maxSpawnRate = 1.5f;
        }
        else if (gameTime > 60f)
        {
            minSpawnRate = 0.5f;
            maxSpawnRate = 1.2f;
        }
        else if (gameTime > 120f)
        {
            minSpawnRate = 0.3f;
            maxSpawnRate = 0.8f;
        }
    }
}