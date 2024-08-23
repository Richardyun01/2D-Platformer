using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Boss3AI : MonoBehaviour
{
    public Transform player;
    public float shootDistance = 3f;
    public float shootInterval = 3f;
    public float shootIntervalCurrent = 0f;
    public GameObject bullet;

    public float multiShotDelay = 0.2f; // 각 탄 사이의 지연 시간

    private Rigidbody2D rb;

    protected void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer < shootDistance)
        {
            if (shootIntervalCurrent < 0)
            {
                StartCoroutine(ShootAttack());
                shootIntervalCurrent = shootInterval;
            }
        }

        shootIntervalCurrent -= Time.deltaTime;
    }

    private IEnumerator ShootAttack()
    {
        for (int i = 0; i < 7; i++) // 3발 발사
        {
            GameObject shot = Instantiate(bullet, transform.position, Quaternion.identity);
            Vector3 playerPos = player.position - transform.position;
            shot.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(playerPos.y, playerPos.x) * 180 / Mathf.PI);

            yield return new WaitForSeconds(multiShotDelay); // 각 탄 사이의 지연 시간
        }
    }
}
