using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialDisable : MonoBehaviour
{
    // 이 스크립트를 추가한 오브젝트를 시작 시 비활성화합니다.
    void Start()
    {
        // 오브젝트를 비활성화합니다.
        gameObject.SetActive(false);
    }
}

