using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FIreBreath : MonoBehaviour
{
    public float FireDamage = 2f;
    float FireCoolTime = 0.5f;
    float NextFireTime = 0f;

    public float MaxGauge = 100f;
    public float Gauge = 100f;
    public float GaugeSpeed = 25f;

    public bool GaugeLock = false;
    public float RecoveryDelay = 1.5f;
    public float RecoveryTimer = 0f;

    public Slider GaugeSilder;
 
    public Transform FireAttackPos;
    public Vector2 boxSize;
    float attackDirection = 1.7f;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            attackDirection = -1.7f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            attackDirection = 1.7f;
        }
        FireAttackPos.localPosition = new Vector2(attackDirection, 0);
        
        if(Input.GetMouseButton(0))
        {
            FIre_Breath();
        }
        else if(Gauge < MaxGauge && !GaugeLock)
        {
            Gauge += GaugeSpeed * Time.deltaTime;
        }
        else if (GaugeLock)
        {

            RecoveryTimer -= Time.deltaTime;
            if (RecoveryTimer <= 0)
            {
                GaugeLock = false;
            }
        }
        else
        {
            Gauge = 100;
        }
        GaugeSilder.value = Gauge/MaxGauge;
    }
    void FIre_Breath()
    {
        if(Gauge > 0)
        {
            Gauge -= GaugeSpeed * Time.deltaTime;
        }
        else
        {
            GaugeLock = true;
            RecoveryTimer = RecoveryDelay;
        }
        if (Time.time >= NextFireTime && !GaugeLock)
        {
            Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(FireAttackPos.position, boxSize, 0);
            foreach (Collider2D collider in collider2Ds)
            {
                if (collider.tag == "Enemy")
                {
                    Debug.Log("적을 때림");
                }
            }

            NextFireTime = Time.time + FireCoolTime;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(FireAttackPos.position, boxSize);
    }
}
