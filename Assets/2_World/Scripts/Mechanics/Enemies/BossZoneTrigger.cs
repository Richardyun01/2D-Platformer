using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossZoneTrigger : MonoBehaviour
{
    public BossHealthBar bossHealthBar; // 보스 체력바 스크립트 참조
    private bool playerInZone = false;  // 플레이어가 존 안에 있는지 여부

    void Start()
    {
        if (bossHealthBar != null)
        {
            bossHealthBar.bossHealthBarUI.SetActive(false); // 처음에는 비활성화
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = true;
            if (bossHealthBar != null)
            {
                bossHealthBar.bossHealthBarUI.SetActive(true); // 플레이어가 존에 들어오면 체력바 활성화
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = false;
            if (bossHealthBar != null)
            {
                bossHealthBar.bossHealthBarUI.SetActive(false); // 플레이어가 존을 떠나면 체력바 비활성화
            }
        }
    }

    void Update()
    {
        if (playerInZone && bossHealthBar != null)
        {
            if (bossHealthBar.bossHealthBarUI.activeSelf == false)
            {
                bossHealthBar.bossHealthBarUI.SetActive(true); // 존 안에 있을 때 계속해서 체력바 활성화
            }
        }
    }
}


