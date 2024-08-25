using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public EnemyManager enemyManager;
    private int currentHealth;
    private HitSoundEffect hitSoundEffect;

    void Start()
    {
        currentHealth = maxHealth;
        hitSoundEffect = GetComponent<HitSoundEffect>();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (hitSoundEffect != null)
        {
            hitSoundEffect.PlayHitSound();
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
        Destroy(gameObject);
    }
}
