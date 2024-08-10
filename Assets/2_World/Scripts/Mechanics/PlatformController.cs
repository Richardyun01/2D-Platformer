using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlatformController : MonoBehaviour
{
    // 플랫폼 활성화 시 호출되는 이벤트
    public UnityEvent onActivate;

    // 플랫폼 비활성화 시 호출되는 이벤트
    public UnityEvent onDeactivate;

    // 현재 플랫폼의 활성화 상태
    private bool isActive = false;

    void Start()
    {
        // 플랫폼이 처음에는 비활성화된 상태로 시작
        gameObject.SetActive(false);
    }

    // 외부에서 호출 가능한 활성화 메서드
    public void ActivatePlatform()
    {
        if (!isActive)
        {
            isActive = true;
            gameObject.SetActive(true);
            onActivate.Invoke();  // 활성화 이벤트 호출
        }
    }

    // 외부에서 호출 가능한 비활성화 메서드
    public void DeactivatePlatform()
    {
        if (isActive)
        {
            isActive = false;
            onDeactivate.Invoke();  // 비활성화 이벤트 호출
            gameObject.SetActive(false);
        }
    }
}
