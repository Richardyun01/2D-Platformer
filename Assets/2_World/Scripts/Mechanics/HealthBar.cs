using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBarImage; // 체력바의 이미지
    public Sprite[] healthBarSprites; // 체력 상태에 따라 변경될 스프라이트 배열 (100%, 80%, 60%, 40%, 20%, 0%)

    private PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        UpdateHealthBar(playerHealth.currentHealth);
    }

    public void UpdateHealthBar(float currentHealth)
    {
        int spriteIndex = Mathf.FloorToInt((currentHealth / playerHealth.maxHealth) * (healthBarSprites.Length - 1));
        healthBarImage.sprite = healthBarSprites[spriteIndex];
    }
}

