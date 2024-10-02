using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public GameObject cloudPrefab;
    public float minSpawnHeight = -.5f;
    public float maxSpawnHeight = 1.2f;
    public float minSpawnInterval = 5f;
    public float maxSpawnInterval = 8f;
    public int poolSize = 5;
    public int maxPoolSize = 10;

    private List<GameObject> cloudPool;
    private float spawnInterval;
    private float timeSinceLastSpawn;

    void Start()
    {
        cloudPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject cloud = Instantiate(cloudPrefab);
            cloud.SetActive(false);
            cloudPool.Add(cloud);
        }
        spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnCloud();
            timeSinceLastSpawn = 0;
            spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
        }
    }

    void SpawnCloud()
    {
        for (int i = 0; i < cloudPool.Count; i++)
        {
            if (!cloudPool[i].activeInHierarchy)
            {
                float spawnHeight = Random.Range(minSpawnHeight, maxSpawnHeight);
                Vector3 spawnPosition = new Vector3(10f, spawnHeight, 0f);
                cloudPool[i].transform.position = spawnPosition;
                cloudPool[i].SetActive(true);
                return;
            }
        }

        if (cloudPool.Count < maxPoolSize)
        {
            float spawnHeight = Random.Range(minSpawnHeight, maxSpawnHeight);
            Vector3 spawnPosition = new Vector3(10f, spawnHeight, 0f);
            GameObject newCloud = Instantiate(cloudPrefab, spawnPosition, Quaternion.identity);
            cloudPool.Add(newCloud);
        }
        else
        {
            cloudPool[0].SetActive(false);
            float spawnHeight = Random.Range(minSpawnHeight, maxSpawnHeight);
            Vector3 spawnPosition = new Vector3(10f, spawnHeight, 0f);
            cloudPool[0].transform.position = spawnPosition;
            cloudPool[0].SetActive(true);
            cloudPool.Add(cloudPool[0]);
            cloudPool.RemoveAt(0);
        }
    }
}
