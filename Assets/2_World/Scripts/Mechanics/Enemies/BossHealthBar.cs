using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    public Image healthBarImage; // 체력바의 이미지
    public Sprite[] healthBarSprites; // 체력 상태에 따라 변경될 스프라이트 배열 (100%, 80%, 60%, 40%, 20%, 0%)

    private EnemyHealth bossHealth;
    private GameObject player; // 플레이어 오브젝트 참조
    public GameObject bossHealthBarUI; // 보스 체력바 UI (Zone 안에서만 활성화)

    void Start()
    {
        bossHealthBarUI.SetActive(false); // 처음에는 비활성화
        player = GameObject.FindWithTag("Player"); // 플레이어 오브젝트 찾기
        bossHealth = GetComponentInParent<EnemyHealth>(); // 부모 오브젝트의 EnemyHealth 참조
    }

    void Update()
    {
        if (bossHealth.currentHealth > 0 && IsPlayerInZone())
        {
            bossHealthBarUI.SetActive(true);
            UpdateHealthBar(bossHealth.currentHealth);
        }
        else
        {
            bossHealthBarUI.SetActive(false);
        }
    }

    private bool IsPlayerInZone()
    {
        // 플레이어가 Zone 안에 있는지 확인하는 로직
        // 플레이어와 보스의 거리 또는 특정 트리거를 사용하여 플레이어가 Zone에 있는지 확인
        return true; // 임시로 true를 반환 (Zone 체크 로직 추가 필요)
    }

    public void UpdateHealthBar(int currentHealth)
    {
        int spriteIndex = Mathf.FloorToInt((currentHealth / (float)bossHealth.maxHealth) * (healthBarSprites.Length - 1));
        healthBarImage.sprite = healthBarSprites[spriteIndex];
    }
}


