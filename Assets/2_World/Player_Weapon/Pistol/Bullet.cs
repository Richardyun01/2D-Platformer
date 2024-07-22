using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D Rigidbody;
    void Start()
    {
        
    }
    private void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //총알이 Player 태그를 가지지 않는 물체를 맞추면 사라짐, Enemy 태그를 가진 물체를 맞추면 맞췄다는 문구가 뜨고 사라짐
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("적을 맞춤");
            Destroy(this.gameObject);
        }

        //벽이나 바닥에 닿았을 때(platform 태그를 가진 물체) 총알이 사라짐
        if (collision.gameObject.tag == "Platform")
        {
            Destroy(this.gameObject);
        }
    }
}
