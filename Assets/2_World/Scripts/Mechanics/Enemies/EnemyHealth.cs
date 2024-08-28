using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public EnemyManager enemyManager;
    public int currentHealth;
    private HitSoundEffect hitSoundEffect;

    private BossHealthBar bossHealthBar;

    void Start()
    {
        currentHealth = maxHealth;
        hitSoundEffect = GetComponent<HitSoundEffect>();
        bossHealthBar = GetComponentInChildren<BossHealthBar>();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (hitSoundEffect != null)
        {
            hitSoundEffect.PlayHitSound();
        }

        if (bossHealthBar != null)
        {
            bossHealthBar.UpdateHealthBar(currentHealth);
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (enemyManager != null)
        {
            enemyManager.OnEnemyDefeated(gameObject);
        }

        if (bossHealthBar != null)
        {
            bossHealthBar.gameObject.SetActive(false); // 보스 사망 시 체력바 비활성화
        }

        Destroy(gameObject);
    }
}
