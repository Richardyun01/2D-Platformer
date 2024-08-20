using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGameClear : MonoBehaviour
{
    public GameManagerScript gameManager;
    public GameObject player;

    public int stageNumber; // 현재 스테이지 번호
    public GameObject[] enemies; // 적 오브젝트 배열

    private void Start()
    {
        // 적 배열 초기화
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    private void Update()
    {
        // 적이 모두 처치되었는지 확인
        if (AreAllEnemiesDefeated())
        {
            GameCleared();
        }
    }

    private bool AreAllEnemiesDefeated()
    {
        foreach (GameObject enemy in enemies)
        {
            if (enemy != null) // 아직 존재하는 적이 있다면
            {
                return false;
            }
        }
        return true; // 모든 적이 처치되었다면
    }

    private void GameCleared()
    {
        Debug.Log("Game Cleared");
        player.SetActive(false);
        if (gameManager != null)
        {
            gameManager.gameClear();
            PlayerPrefs.SetInt("Stage" + stageNumber + "Cleared", 1); // 스테이지 클리어 상태 저장
        }
        else
        {
            Debug.LogError("GameManagerScript is not assigned.");
        }
    }
}
