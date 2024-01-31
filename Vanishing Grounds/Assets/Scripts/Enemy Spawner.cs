using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // prefab is for the spawned enemy
    public GameObject prefab; 
    public Vector2 origin = Vector2.zero;
    public float limit_minX = -1.0f;
    public float limit_maxX = 2.0f;
    public float limit_minY = -1.0f;
    public float limit_maxY = 2.0f;
    public float spawnInterval = 3.0f;
 
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0.0f, spawnInterval);
    }
       
    void SpawnEnemy()
    {
        float randomX = Random.Range(limit_minX, limit_maxX);
        float randomY = Random.Range(limit_minY, limit_maxY);

        Vector2 randomPosition = new Vector2(randomX, randomY);
        Instantiate(prefab, randomPosition, Quaternion.identity);
    }
}