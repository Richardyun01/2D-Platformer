using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkedDeactivation : MonoBehaviour
{
    public GameObject linkedObject; // 연관된 오브젝트

    void Update()
    {
        if (linkedObject == null || !linkedObject.activeInHierarchy)
        {
            gameObject.SetActive(false); // 이 오브젝트도 비활성화
        }
    }
}

