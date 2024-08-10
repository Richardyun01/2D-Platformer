using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeonBladeLeft : MonoBehaviour
{
    public float LeftBladeDamage = 2f;
    float LeftBladeCoolTime = 0.5f;
    float NextLeftBladeTime = 0f;

    public Transform BladeAttackPos;
    public Vector2 boxSize;
    float attackDirection = 0.7f;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            attackDirection = -0.7f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            attackDirection = 0.7f;
        }
        BladeAttackPos.localPosition = new Vector2(attackDirection, 0);

        Blade_Sweep();
    }
    void Blade_Sweep()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (Time.time >= NextLeftBladeTime)
            {
                Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(BladeAttackPos.position, boxSize, 0);
                foreach (Collider2D collider in collider2Ds)
                {
                    if (collider.tag == "Enemy")
                    {
                        Debug.Log("적을 때림");
                    }
                }

                NextLeftBladeTime = Time.time + LeftBladeCoolTime;
            }
            else
            {
                Debug.Log("네온 블레이드(좌) 쿨타임 안됨");
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(BladeAttackPos.position, boxSize);
    }
}