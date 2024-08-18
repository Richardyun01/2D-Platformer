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
    private bool isDead;
    public GameManagerScript gameManager;

    void Start()
    {
        currentHealth = maxHealth;
        currentDefence = 0;
        UpdateHealthUI();
    }

    public void UpdateHealthUI()
    {
        healthText.text = "Health: " + currentHealth.ToString();
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
    }
    public void IncreaseHP(float HpAmount)
    {
        currentHealth += HpAmount;
    }
    void Update()
    {
        if (currentHealth > 100)
        {
            currentHealth = 100;
        }
    }
}

