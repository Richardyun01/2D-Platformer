 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Gameplay;
using static Platformer.Core.Simulation;
using Platformer.Model;
using Platformer.Core;

namespace Platformer.Mechanics
{
    /// <summary>
    /// This is the main class used to implement control of the player.
    /// It is a superset of the AnimationController class, but is inlined to allow for any kind of customisation.
    /// </summary>
    public class PlayerController : KinematicObject
    {
        public AudioClip jumpAudio;
        public AudioClip respawnAudio;
        public AudioClip ouchAudio;

        /// <summary>
        /// Max horizontal speed of the player.
        /// </summary>
        public float maxSpeed = 7;
        /// <summary>
        /// Initial jump velocity at the start of a jump.
        /// </summary>
        public float jumpTakeOffSpeed = 5;

        public JumpState jumpState = JumpState.Grounded;
        private bool stopJump;
        /*internal new*/ public Collider2D collider2d;
        /*internal new*/ public AudioSource audioSource;
        public Health health;
        public bool controlEnabled = true;

        bool jump;
        [SerializeField] bool checkDoubleJump;
        [SerializeField] int jumpCount;
        Vector2 move;
        SpriteRenderer spriteRenderer;
        internal Animator animator;
        readonly PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        private bool ignorePlatform;

        Rigidbody2D rigid;
        Vector2 KB;

        public Bounds Bounds => collider2d.bounds;

        PlayerHealth playerHealth;

        void Awake()
        {
            health = GetComponent<Health>();
            playerHealth = GetComponent<PlayerHealth>();
            audioSource = GetComponent<AudioSource>();
            collider2d = GetComponent<Collider2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
            rigid = GetComponent<Rigidbody2D>();
            checkDoubleJump = false;
            jumpCount = 0;
        }

        protected override void Update()
        {
            if (controlEnabled)
            {
                move.x = 0; // 초기화

                if (Input.GetKey(KeyCode.A))
                {
                    move.x = -1;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    move.x = 1;
                }
                if (jumpState == JumpState.Grounded && Input.GetButtonDown("Jump"))
                {
                    jumpState = JumpState.PrepareToJump;
                    jumpCount = 1;
                }
                // 더블 점프 체크: 아이템으로 true로 만듬
                else if (Input.GetButtonDown("Jump") && jumpCount < 2 && checkDoubleJump == true)
                {
                    jumpState = JumpState.PrepareToJump;
                    jumpCount = 2;
                }
                else if (Input.GetButtonUp("Jump"))
                {
                    stopJump = true;
                    Schedule<PlayerStopJump>().player = this;
                }

                if (Input.GetKeyDown(KeyCode.S))
                {
                    ignorePlatform = true;
                }
                else if (Input.GetKeyUp(KeyCode.S))
                {
                    ignorePlatform = false;
                }
            }
            else
            {
                move.x = 0;
            }
            UpdateJumpState();
            base.Update();
        }

        /*
        void CanMove()
        {
            if (FindObjectOfType<InteractionSystem>().isExamining)
                controlEnabled = false;
        }
        */

        void UpdateJumpState()
        {
            jump = false;
            switch (jumpState)
            {
                case JumpState.PrepareToJump:
                    jumpState = JumpState.Jumping;
                    jump = true;
                    stopJump = false;
                    break;
                case JumpState.Jumping:
                    if (!IsGrounded)
                    {
                        Schedule<PlayerJumped>().player = this;
                        jumpState = JumpState.InFlight;
                    }
                    break;
                case JumpState.InFlight:
                    if (IsGrounded)
                    {
                        Schedule<PlayerLanded>().player = this;
                        jumpState = JumpState.Landed;
                    }
                    break;
                case JumpState.Landed:
                    jumpState = JumpState.Grounded;
                    jumpCount = 0;
                    break;
                // 추가: Grounded 상태를 확인해서 설정
                case JumpState.Grounded:
                    if (!IsGrounded)
                    {
                        //Schedule<PlayerLanded>().player = this;
                        jumpState = JumpState.InFlight;
                    }
                    break;
            }
        }

        protected override void ComputeVelocity()
        {
            if (jump && (IsGrounded || jumpCount == 2))
            {
                velocity.y = jumpTakeOffSpeed * model.jumpModifier;
                jump = false;
            }
            else if (stopJump)
            {
                stopJump = false;
                /*
                if (velocity.y > 0)
                {
                    velocity.y = velocity.y; * model.jumpDeceleration;
                }
                */
            }

            // x축 방향 속도 조정(버프) -> 차후 별도 파일로 분리
            // if () velocity().x = ;

            if (move.x > 0.01f)
                spriteRenderer.flipX = false;
            else if (move.x < -0.01f)
                spriteRenderer.flipX = true;

            animator.SetBool("grounded", IsGrounded);
            animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

            targetVelocity = move * maxSpeed + KB;

            KB /= 1.1f;
            if (KB.sqrMagnitude < 0.1f)
            {
                controlEnabled = true;
            }
        }

        public bool ShouldIgnorePlatform()
        {
            return ignorePlatform;
        }

        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                EnemyCollision knockback = collision.gameObject.GetComponent<EnemyCollision>();
                playerHealth.TakeDamage(knockback.damage);
                OnDamaged(collision.transform.position, knockback.KBforceX, knockback.KBforceY);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                EnemyCollision knockback = collision.gameObject.GetComponent<EnemyCollision>();
                playerHealth.TakeDamage(knockback.damage);
                OnDamaged(collision.transform.position, knockback.KBforceX, knockback.KBforceY);
                if (collision.gameObject.GetComponent<EnemyBullet>() != null)
                {
                    Destroy(collision.gameObject);
                }
            }
        }

        void OnDamaged(Vector2 targetPos, float knockbackX, float knockbackY)
        {
            gameObject.layer = 11;
            spriteRenderer.color = new Color(1, 1, 1, 0.4f);
            int dircX = transform.position.x - targetPos.x > 0 ? 1 : -1;
            int dircY = transform.position.y - targetPos.y > 0 ? 1 : -1; //dircY * maxSpeed * knockbackY
            KB = new Vector2(dircX * maxSpeed * knockbackX, 0);
            controlEnabled = false;
            Debug.Log("OnDamaged");

            Invoke("OffDamaged", 2);
        }

        void OffDamaged()
        {
            gameObject.layer = 3;
            spriteRenderer.color = new Color(1, 1, 1, 1);
            //move.x = 0;
            //controlEnabled = true;
            Debug.Log("OffDamaged");
        }

        public enum JumpState
        {
            Grounded,
            PrepareToJump,
            Jumping,
            InFlight,
            Landed
        }
    }
}