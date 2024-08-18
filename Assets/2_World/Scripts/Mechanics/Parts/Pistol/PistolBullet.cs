using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float LifeTime = 0.5f;
    public int damage = 5;
    void Start()
    {
        Destroy(gameObject, LifeTime);
    }
    private void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //총알이 Player 태그를 가지지 않는 물체를 맞추면 사라짐, Enemy 태그를 가진 물체를 맞추면 맞췄다는 문구가 뜨고 사라짐
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("적을 맞춤");
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }
            Destroy(this.gameObject);
        }

        //벽이나 바닥에 닿았을 때(Platform 또는 OneWayPlatform 태그를 가진 물체) 총알이 사라짐
        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "OneWayPlatform" )
        {
            // 플랫폼이 BreakablePlatform 스크립트를 가지고 있는지 확인
            BreakablePlatform breakablePlatform = collision.gameObject.GetComponent<BreakablePlatform>();
            if (breakablePlatform != null)
            {
                breakablePlatform.TakeDamage(damage);
            }

            Destroy(this.gameObject);
        }
    }
}
