using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    //ÃÑ ½ºÅÝ °ü·Ã º¯¼ö, ³ªÁß¿¡ °­È­µÇ¸é ¹Ù²ð ¼ö ÀÖÀ½
    public float PistolDamage = 1f;
    public float BulletSpeed = 8.0f;
    float FireCoolTIme = 0.5f;
    float NextFireTime = 0f;

    public GameObject bulletPos;
    [SerializeField] GameObject BulletPref;
    Vector2 BulletDir;
    Camera cam;
    void Start()
    {
        cam = Camera.main;
    }
    void Update()
    {
        Shoot();
        BulletDir = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(BulletDir.y, BulletDir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        BulletDir.Normalize();
    }
    void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time >= NextFireTime)
            {
                GameObject Bullet = Instantiate(BulletPref, bulletPos.transform.position, transform.rotation);
                Rigidbody2D rigidbody = Bullet.GetComponent<Rigidbody2D>();
                Bullet.gameObject.GetComponent<Rigidbody2D>().AddForce(BulletDir * BulletSpeed, ForceMode2D.Impulse);

                NextFireTime = Time.time + FireCoolTIme;
            }
            else
            {
                Debug.Log("ÄðÅ¸ÀÓ ¾ÈµÊ");
            }
        }
    }
}
