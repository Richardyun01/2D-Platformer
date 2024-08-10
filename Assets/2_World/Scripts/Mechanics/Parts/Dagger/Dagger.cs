using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dagger : MonoBehaviour
{
    public float DaggerDamage = 1f;
    float DaggerCoolTime = 1f;
    float NextDaggerTime = 0f;

    public Transform DaggerAttackPos;
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
        DaggerAttackPos.localPosition = new Vector2(attackDirection, 0);

        Dagger_Sweep();
    }
    void Dagger_Sweep()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (Time.time >= NextDaggerTime)
            {
                Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(DaggerAttackPos.position, boxSize, 0);
                foreach (Collider2D collider in collider2Ds)
                {
                    if (collider.tag == "Enemy")
                    {
                        Debug.Log("���� ����");
                    }
                }

                NextDaggerTime = Time.time + DaggerCoolTime;
            }
            else
            {
                Debug.Log("��� ��Ÿ�� �ȵ�");
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(DaggerAttackPos.position, boxSize);
    }
}