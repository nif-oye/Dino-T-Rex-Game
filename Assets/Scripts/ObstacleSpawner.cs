using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public List<GameObject> obstaclePrefabs;  
    public float minSpawnRate = 1f;
    public float maxSpawnRate = 3f;
    public float timeSinceLastSpawn;
    public int poolSize = 5;
    public int maxPoolSize = 10;
    private Dictionary<GameObject, List<GameObject>> obstaclePools;
    private float spawnRate;

    void Start()
    {
        obstaclePools = new Dictionary<GameObject, List<GameObject>>();

        foreach (GameObject prefab in obstaclePrefabs)
        {
            obstaclePools[prefab] = new List<GameObject>();
            for (int i = 0; i < poolSize; i++)
            {
                GameObject obj = Instantiate(prefab);
                obj.SetActive(false);
                obstaclePools[prefab].Add(obj);
            }
        }

        spawnRate = Random.Range(minSpawnRate, maxSpawnRate);
    }

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= spawnRate)
        {
            SpawnRandomObstacle();
            timeSinceLastSpawn = 0;  
            spawnRate = Random.Range(minSpawnRate, maxSpawnRate);
        }

        AdjustSpawnRate();
    }

    void SpawnRandomObstacle()
    {
        GameObject randomPrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Count)];

        for (int i = 0; i < obstaclePools[randomPrefab].Count; i++)
        {
            if (!obstaclePools[randomPrefab][i].activeInHierarchy)
            {
                obstaclePools[randomPrefab][i].transform.position = transform.position;
                obstaclePools[randomPrefab][i].SetActive(true);
                return;
            }
        }

        if (obstaclePools[randomPrefab].Count < maxPoolSize)
        {
            GameObject newObstacle = Instantiate(randomPrefab, transform.position, Quaternion.identity);
            obstaclePools[randomPrefab].Add(newObstacle);
        }
        else
        {
            GameObject reusedObstacle = obstaclePools[randomPrefab][0];
            reusedObstacle.transform.position = transform.position;
            reusedObstacle.SetActive(true);
            obstaclePools[randomPrefab].Add(reusedObstacle);
            obstaclePools[randomPrefab].RemoveAt(0);
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
