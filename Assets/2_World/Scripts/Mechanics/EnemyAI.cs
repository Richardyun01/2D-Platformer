using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float detectionRangeX = 300f;
    public float detectionRangeY = 200f;
    public float chaseSpeed = 300f;
    public float aggroTime = 5f;
    public float attackRange = 100f;

    private Transform player;
    private bool isAggroed = false;
    private float aggroCounter = 0f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float distanceX = Mathf.Abs(player.position.x - transform.position.x);
        float distanceY = Mathf.Abs(player.position.y - transform.position.y);

        if (distanceX < detectionRangeX && distanceY < detectionRangeY)
        {
            isAggroed = true;
            aggroCounter = aggroTime;
        }

        if (isAggroed)
        {
            aggroCounter -= Time.deltaTime;
            if (aggroCounter <= 0)
            {
                isAggroed = false;
            }

            ChasePlayer();
        }
    }

    private void ChasePlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * chaseSpeed * Time.deltaTime;
    }

    public void OnTakeDamage()
    {
        isAggroed = true;
        aggroCounter = aggroTime;
    }
}
