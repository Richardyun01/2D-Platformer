using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Boss2AI : MonoBehaviour
{
    public List<Transform> points;
    public int nextID;
    int idChangeValue = 1;
    public float speed = 2;

    public Transform player;
    public float chaseDistance = 3f;
    public float returnDistance = 5f;

    private Rigidbody2D rb;
    private Vector2 initialPosition;
    private bool isGrounded;
    private bool isChasingPlayer = false;
    private bool isReturning = false;

    public float shootDistance = 3f;
    public float shootInterval = 3f;
    public float shootIntervalCurrent = 0f;
    public GameObject bullet;

    public float multiShotDelay = 0.2f; // 각 탄 사이의 지연 시간

    public SoundTrigger soundTrigger;

    protected void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        initialPosition = transform.position;
    }

    private void Reset()
    {
        Init();
    }

    void Init()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer < chaseDistance)
        {
            isChasingPlayer = true;
            isReturning = false;
            ChasePlayer();
        }
        else if (isChasingPlayer && distanceToPlayer > returnDistance)
        {
            isChasingPlayer = false;
            isReturning = true;
        }

        if (distanceToPlayer < shootDistance)
        {
            if (shootIntervalCurrent < 0)
            {
                StartCoroutine(ShootAttack());
                shootIntervalCurrent = shootInterval;
            }
        }

        if (isReturning)
        {
            ReturnToInitialPosition();
        }
        else if (!isChasingPlayer && !isReturning && points.Count > 0)
        {
            MoveToNextPoint();
        }

        shootIntervalCurrent -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(transform.position, 0.1f, LayerMask.GetMask("Ground"));
    }

    private void ChasePlayer()
    {
        if (player.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
    }

    private void ReturnToInitialPosition()
    {
        if (Vector2.Distance(transform.position, initialPosition) > 0.1f)
        {
            if (initialPosition.x > transform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
            isReturning = false;  // 복귀 완료
        }
    }

    private void MoveToNextPoint()
    {
        Transform goalPoint = points[nextID];
        if (goalPoint.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }

        if (Vector2.Distance(transform.position, goalPoint.position) < 1f)
        {
            if (nextID == points.Count - 1)
                idChangeValue = -1;
            if (nextID == 0)
                idChangeValue = 1;
            nextID += idChangeValue;
        }
    }

    private IEnumerator ShootAttack()
    {
        for (int i = 0; i < 5; i++) // 3발 발사
        {
            GameObject shot = Instantiate(bullet, transform.position, Quaternion.identity);
            Vector3 playerPos = player.position - transform.position;
            shot.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(playerPos.y, playerPos.x) * 180 / Mathf.PI);

            yield return new WaitForSeconds(multiShotDelay); // 각 탄 사이의 지연 시간
        }
    }

    private void OnDestroy()
    {
        if (soundTrigger != null)
        {
            soundTrigger.DisableZone(); // 소리 재생 오브젝트 비활성화
        }
    }
}
