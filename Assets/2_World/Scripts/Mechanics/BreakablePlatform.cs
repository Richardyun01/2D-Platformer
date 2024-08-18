using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakablePlatform : MonoBehaviour
{
    public int health = 1;  // 플랫폼의 체력
    //public GameObject brokenPlatformPrefab;  // 부서진 플랫폼의 프리팹

    // 탄환과 충돌 시 호출될 메서드
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            BreakPlatform();
        }
    }

    void BreakPlatform()
    {
        // 부서진 플랫폼 생성
        /*
        if (brokenPlatformPrefab != null)
        {
            Instantiate(brokenPlatformPrefab, transform.position, transform.rotation);
        }
        */

        // 현재 플랫폼 오브젝트 제거
        Destroy(gameObject);
    }
}
