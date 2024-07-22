using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    //공격력 변수 생성, 강화 능력 등으로 변경될 수 있는 수치
    public float attack = 1f;
    public float BulletSpeed = 8.0f;
    [SerializeField] GameObject BulletPref;
    int rotation;
    void Start()
    {
        
    }

    void Update()
    {
        //나중에 방향에 대한 정보를 받을 시 수정 (임시 코드)
        if(Input.GetAxis("Horizontal")>0)
        {
            rotation = 1;
        }
        else
        {
            rotation = -1;
        }

        if (Input.GetMouseButtonDown(0))
        {
            GameObject Bullet = Instantiate(BulletPref, transform.position, transform.rotation);
            Rigidbody2D rigidbody = Bullet.GetComponent<Rigidbody2D>();
            rigidbody.velocity = Vector2.right * rotation * BulletSpeed;
        }
    }
}
