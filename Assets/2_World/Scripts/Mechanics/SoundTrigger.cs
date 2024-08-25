using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    public AudioSource audioSource;  // 효과음을 재생할 AudioSource
    private bool isPlayerInside = false;  // 플레이어가 영역 안에 있는지 확인하는 플래그
    private bool isZoneEnabled = true;  // 영역이 활성화되어 있는지 확인하는 플래그

    void Update()
    {
        // 영역이 활성화된 경우에만 오디오를 재생
        if (isZoneEnabled && isPlayerInside && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
        else if (!isZoneEnabled && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    // 플레이어가 트리거 영역에 들어왔을 때 호출
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isZoneEnabled && other.CompareTag("Player"))
        {
            isPlayerInside = true;
            audioSource.Play();
        }
    }

    // 플레이어가 트리거 영역에서 나갔을 때 호출
    private void OnTriggerExit2D(Collider2D other)
    {
        if (isZoneEnabled && other.CompareTag("Player"))
        {
            isPlayerInside = false;
            audioSource.Stop();
        }
    }

    // 외부에서 호출하여 영역을 비활성화하는 함수
    public void DisableZone()
    {
        isZoneEnabled = false;
        audioSource.Stop();  // 현재 재생 중인 오디오도 정지
    }

    // 외부에서 호출하여 영역을 활성화하는 함수 (선택 사항)
    public void EnableZone()
    {
        isZoneEnabled = true;
    }
}

