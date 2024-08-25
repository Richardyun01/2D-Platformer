using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public float currentHealth;
    public int currentDefence;

    public Text healthText;
    public Text statusText;
    public Text maxStatusText;
    private bool isDead;
    public GameManagerScript gameManager;

    void Start()
    {
        currentHealth = maxHealth;
        currentDefence = 0;
        UpdateHealthUI();
        UpdateStatusUI();
        UpdateMaxStatusUI();
    }

    public void UpdateHealthUI()
    {
        healthText.text = "Health: " + currentHealth.ToString("F1");
    }

    public void UpdateStatusUI()
    {
        statusText.text = "현재 체력: " + Mathf.RoundToInt(currentHealth).ToString();
    }

    public void UpdateMaxStatusUI()
    {
        maxStatusText.text = "- 최대 HP: " + maxHealth.ToString();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= (damage - currentDefence);
        if (currentHealth <= 0 && !isDead)
        {
            isDead = true;
            gameObject.SetActive(false);
            currentHealth = 0;
            gameManager.gameOver();
        }
        UpdateHealthUI();
        UpdateStatusUI();
    }
    public void IncreaseHP(float HpAmount)
    {
        currentHealth += HpAmount;
        UpdateHealthUI();
        UpdateStatusUI();
    }
    void Update()
    {
        if (currentHealth > 100)
        {
            currentHealth = 100;
        }
    }
}

