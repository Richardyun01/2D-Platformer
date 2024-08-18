using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B502Bullet : MonoBehaviour
{
    public float LifeTime = 0.375f;
    public int damage = 5;
    public float explosionRadius = 2f;
    void Start()
    {
        Destroy(gameObject, LifeTime);
    }
    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "OneWayPlatform" || collision.gameObject.tag == "Enemy")
        {
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

                foreach (Collider nearbyObject in colliders)
                {
                    EnemyHealth nearbyEnemy = nearbyObject.GetComponent<EnemyHealth>();

                    if (nearbyEnemy != null)
                    {
                        
                        nearbyEnemy.TakeDamage(damage);
                    }
                }
                enemyHealth.TakeDamage(damage);
            }
            Destroy(this.gameObject);
        }
    }
}
