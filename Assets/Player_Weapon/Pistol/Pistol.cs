using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    //공격력 변수 생성, 강화 능력 등으로 변경될 수 있는 수치
    public float attack = 1f;
    public float BulletSpeed = 8.0f;
    public GameObject BulletPref;
    public Transform BulletPos;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject Bullet = Instantiate(BulletPref, BulletPos.position, transform.rotation);
        }
    }
}
