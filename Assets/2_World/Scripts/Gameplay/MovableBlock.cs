using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class MovableBlock : MonoBehaviour
{
    public float moveSpeed = 5.0f;  // 블록의 이동 속도
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private bool isMoving = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 1;  // 중력의 영향을 받도록 설정
        rb.freezeRotation = true;  // 블록이 회전하지 않도록 설정
    }

    void Update()
    {
        if (isMoving)
        {
            // x축으로만 이동하게 하고, y축은 중력에 따라 자연스럽게 움직이게 설정
            rb.velocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // 플레이어가 충돌한 방향을 감지하고 오직 x축 방향으로만 설정
            Vector2 contactPoint = collision.GetContact(0).point;
            Vector2 center = collision.collider.bounds.center;

            Vector2 direction = (contactPoint - center).normalized;

            // x축 방향으로만 움직이도록 설정하고 y축은 그대로 유지
            moveDirection = new Vector2(Mathf.Round(direction.x), 0);

            // 접촉 시 이동 시작
            isMoving = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // 플레이어와의 접촉이 끝나면 이동 중지
            isMoving = false;
        }
    }
}
