using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dagger : MonoBehaviour
{
    //서슬퍼런 단검 관련 변수, 나중에 강화되면 바뀔 수 있음
    public float DaggerDamage =1f;
    float DaggerCoolTIme = 1f;
    float NextDaggerTime = 0f;
    void Start()
    {

    }
    void Update()
    {
        Sweep();
    }
    void Sweep()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if(Time.time >= NextDaggerTime)
            {
                
                NextDaggerTime = Time.time + DaggerCoolTIme;
            }
            else
            {
                Debug.Log("쿨타임 안됨");
            }
        }
    }
}
