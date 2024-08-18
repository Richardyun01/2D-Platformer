using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float bulletSpeed = 3f;
    public float bulletLifeTime = 5f;
    public float bulletLifeTimeCurrent;

    void Awake()
    {
        bulletLifeTimeCurrent = bulletLifeTime;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * bulletSpeed * Time.deltaTime;
        if (bulletLifeTimeCurrent < 0)
        {
            Destroy(gameObject);
        }
        bulletLifeTimeCurrent -= Time.deltaTime;
    }
}
