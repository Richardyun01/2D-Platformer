using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Boss1AI : MonoBehaviour
{
    public List<Transform> points;
    public int nextID;
    int idChangeValue = 1;
    public float speed = 2;

    public Transform player;
    public float chaseDistance = 3f;
    public float returnDistance = 5f;
    public float jumpForce = 7f;
    public float diveSpeed = 10f;
    public float diveDelay = 0.5f; // 내리찍기 전 대기 시간
    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private Vector2 initialPosition;
    private bool isGrounded;
    private bool isChasingPlayer = false;
    private bool isReturning = false;
    private bool isDiving = false;

    protected void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        initialPosition = transform.position;

        // 디버깅 로그 추가
        Debug.Log("EnemyAI Initialized");
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
        // 플레이어와의 거리 계산
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // 디버깅 로그 추가
        Debug.Log($"Distance to Player: {distanceToPlayer}, Chase Distance: {chaseDistance}");
        Debug.Log($"Is Grounded: {isGrounded}, Is Chasing: {isChasingPlayer}, Is Returning: {isReturning}, Is Diving: {isDiving}");

        if (distanceToPlayer < chaseDistance && isGrounded && !isDiving)
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

        if (isReturning)
        {
            ReturnToInitialPosition();
        }
        else if (!isChasingPlayer && !isReturning && points.Count > 0)
        {
            MoveToNextPoint();
        }
    }

    private void FixedUpdate()
    {
        // 지면 체크
        isGrounded = Physics2D.OverlapCircle(transform.position, groundCheckRadius, groundLayer);

        // 디버깅 로그 추가
        Debug.Log($"Is Grounded Check: {isGrounded}");
    }

    private void ChasePlayer()
    {
        if (!isDiving && isGrounded)
        {
            // 적이 도약 (점프)하여 플레이어를 공격하도록 구현
            JumpAndDive();
        }
    }

    private void JumpAndDive()
    {
        // 점프
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        StartCoroutine(DiveAttack());
    }

    private IEnumerator DiveAttack()
    {
        // 내리찍기 전 대기 시간 (diveDelay)
        yield return new WaitForSeconds(diveDelay);

        isDiving = true;
        rb.velocity = new Vector2(rb.velocity.x, -diveSpeed);

        // 착지할 때까지 기다림
        while (!isGrounded)
        {
            yield return null;
        }

        isDiving = false;
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
}
