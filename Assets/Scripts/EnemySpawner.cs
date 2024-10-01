using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRate = 2f;
    public float timeSinceLastSpawn;
    public float[] spawnHeights = new float[] { -1.2f, -0.6f, 0f };
    public int poolSize = 5;
    public int maxPoolSize = 10;

    private List<GameObject> enemyPool;

    void Start()
    {
        enemyPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(enemyPrefab);
            obj.SetActive(false);
            enemyPool.Add(obj);
        }
    }

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= spawnRate)
        {
            SpawnEnemy();
            timeSinceLastSpawn = 0;
        }
    }

    void SpawnEnemy()
    {
        for (int i = 0; i < enemyPool.Count; i++)
        {
            if (!enemyPool[i].activeInHierarchy)
            {
                int randomIndex = Random.Range(0, spawnHeights.Length);
                float spawnY = spawnHeights[randomIndex];
                enemyPool[i].transform.position = new Vector3(transform.position.x, spawnY, transform.position.z);
                enemyPool[i].SetActive(true);
                return;
            }
        }

        if (enemyPool.Count < maxPoolSize)
        {
            GameObject newEnemy = Instantiate(enemyPrefab);
            int randomIndex = Random.Range(0, spawnHeights.Length);
            float spawnY = spawnHeights[randomIndex];
            newEnemy.transform.position = new Vector3(transform.position.x, spawnY, transform.position.z);
            newEnemy.SetActive(true);
            enemyPool.Add(newEnemy);
        }
        else
        {
            enemyPool[0].transform.position = new Vector3(transform.position.x, spawnHeights[Random.Range(0, spawnHeights.Length)], transform.position.z);
            enemyPool[0].SetActive(true);
            enemyPool.Add(enemyPool[0]);
            enemyPool.RemoveAt(0);
        }
    }
}
