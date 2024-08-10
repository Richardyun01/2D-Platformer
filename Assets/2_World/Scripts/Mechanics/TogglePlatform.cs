using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleObject : MonoBehaviour
{
    private Renderer objectRenderer;
    private Collider2D objectCollider;
    private bool isPlayerInside = false;  // 플레이어가 트리거 안에 있는지 여부를 추적

    private void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        objectCollider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        // 플레이어가 트리거 안에 있지 않을 때 오브젝트를 활성화
        if (!isPlayerInside && !objectRenderer.enabled)
        {
            ReactivateObject();
        }
    }

    // 플레이어가 트리거에 진입할 때 호출
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // 플레이어가 트리거 안에 있음을 기록하고 오브젝트를 비활성화
            isPlayerInside = true;
            objectRenderer.enabled = false;
            objectCollider.enabled = false;
        }
    }

    // 플레이어가 트리거를 벗어날 때 호출
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // 플레이어가 트리거 밖으로 나갔음을 기록
            isPlayerInside = false;
        }
    }

    private void ReactivateObject()
    {
        objectRenderer.enabled = true;
        objectCollider.enabled = true;
    }
}

