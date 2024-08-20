using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // 소환할 적 프리팹
    public float spawnInterval = 2.0f; // 적 소환 간격
    private bool isSpawning = false;

    public void StartSpawning()
    {
        if (enemyPrefab != null)
        {
            if (!isSpawning)
            {
                isSpawning = true;
                StartCoroutine(SpawnEnemies());
            }
        }
        
    }

    public void StopSpawning()
    {
        isSpawning = false;
        StopCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (isSpawning)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}

