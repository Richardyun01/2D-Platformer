using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;

public class EnemyCollision : MonoBehaviour
{
    public int damage = 10;
    [SerializeField] public float KBforceX = 1;
    [SerializeField] public float KBforceY = 1;
    //public PlayerController playerController;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
        }
    }

    public void setDamage(int damage)
    {
        this.damage = damage;
    }
}

