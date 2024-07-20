using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float BulletSpeed = 10.0f;
    Rigidbody2D Rigidbody;
    public Vector3 spawnPoint;
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        //캐릭터가 보는 방향 벡터를 정하고 RIgidbody로 힘을 가하는데 여기에 버그가 있음
        if (Input.GetAxis("Horizontal")>0)
        {
            spawnPoint = Vector3.right;
        }
        if (Input.GetAxis("Horizontal")<0)
        {
            spawnPoint = Vector3.left;
        }
        Rigidbody.velocity = spawnPoint * BulletSpeed;
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //총알이 Player 태그를 가지지 않는 물체를 맞추면 사라짐, Enemy 태그를 가진 물체를 맞추면 맞췄다는 문구가 뜨고 사라짐
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("적을 맞춤");
            Destroy(this.gameObject);
        }
        if(collision.gameObject.tag != "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
