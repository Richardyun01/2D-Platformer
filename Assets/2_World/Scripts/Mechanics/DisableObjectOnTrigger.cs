using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObjectOnTrigger : MonoBehaviour
{
    // 비활성화할 오브젝트를 연결할 public 변수
    public GameObject objectToDisable;

    // Collider2D가 Trigger 영역에 진입했을 때 호출되는 메서드
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 트리거에 진입한 오브젝트의 태그가 "Player"인 경우에만 실행
        if (other.CompareTag("Player"))
        {
            // 특정 오브젝트를 비활성화
            if (objectToDisable != null)
            {
                objectToDisable.SetActive(false);
            }
        }
    }
}

