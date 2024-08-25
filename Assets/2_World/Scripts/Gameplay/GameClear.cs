using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameClear : MonoBehaviour
{
    public GameManagerScript gameManager;
    public GameObject player;
    [Header("Custom Event")]
    public UnityEvent customEvent;

    public int stageNumber; // 현재 스테이지 번호

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Debug.Log("Game Cleared");
            player.SetActive(false);
            if (gameManager != null)
            {
                customEvent.Invoke();
                gameManager.gameClear();
                PlayerPrefs.SetInt("Stage" + stageNumber + "Cleared", 1); // 스테이지 클리어 상태 저장
            }
            else
            {
                Debug.LogError("GameManagerScript is not assigned.");
            }
        }
    }
}
