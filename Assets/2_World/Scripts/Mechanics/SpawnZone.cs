using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    public EnemySpawner enemySpawner; // 적 소환 스크립트를 연결할 변수

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // 플레이어 태그 확인
        {
            enemySpawner.StartSpawning(); // 적 소환 시작
        }
    }

    /*
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enemySpawner.StopSpawning(); // 적 소환 중지
        }
    }
    */
}

