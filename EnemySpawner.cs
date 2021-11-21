using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    float spawnEnergy = 0;
    float spawnEnergyRefillSpeed;
    float refillUpgradeTimer = 10.0f;
    float spawnRate = 3.0f;

    [System.Serializable]
    public class Enemy
    {
        public GameObject prefab;
        public float energyCost;
        public int poolSize;
        public Queue<GameObject> pool = new Queue<GameObject>();
    }

    public Enemy[] enemiesToSpawn;

    public Transform[] spawnPoints;

    private void Start()
    {
        spawnEnergy = 10;
        spawnEnergyRefillSpeed = 0.2f;
        spawnRate = 2;

        foreach(Enemy e in enemiesToSpawn)
        {
            for (int i = 0; i < e.poolSize; i++)
            {
                GameObject obj = Instantiate(e.prefab, transform.position,Quaternion.identity);
                obj.SetActive(false);
                e.pool.Enqueue(obj);
            }

        }
    }

    private void Update()
    {
        spawnEnergy += spawnEnergyRefillSpeed * Time.deltaTime;
        refillUpgradeTimer -= Time.deltaTime;
        if(refillUpgradeTimer <= 0)
        {
            spawnEnergyRefillSpeed *= 1.15f;
            refillUpgradeTimer = 5;
        }

        spawnRate -= Time.deltaTime;
        if(spawnRate <= 0)
        {
            SpawnEneies();
            spawnRate = 3.0f;
        }
    }

    void SpawnEneies()
    {
        int currentId = enemiesToSpawn.Length-1;
        while(spawnEnergy >= enemiesToSpawn[0].energyCost)
        {
            if(enemiesToSpawn[currentId].energyCost <= spawnEnergy)
            {
                spawnEnergy -= enemiesToSpawn[currentId].energyCost;
                SpawnFromPool(enemiesToSpawn[currentId].pool, spawnPoints[Random.Range(0,spawnPoints.Length)].position, Quaternion.identity);
            } else
            {
                currentId -= 1;
            }
        }
    }

    public GameObject SpawnFromPool(Queue<GameObject> q, Vector3 position, Quaternion rotation)
    {
        GameObject objectToSpawn = q.Dequeue();
        if (objectToSpawn.activeSelf != true)
        {
            objectToSpawn.transform.rotation = rotation;

            objectToSpawn.transform.position = position;
            objectToSpawn.SetActive(true);

            q.Enqueue(objectToSpawn);

        }
        return objectToSpawn;
    }
}
