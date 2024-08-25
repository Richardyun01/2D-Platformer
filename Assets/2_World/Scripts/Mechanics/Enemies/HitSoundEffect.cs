using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSoundEffect : MonoBehaviour
{
    public AudioClip hitSound;  // 피격 효과음 클립
    private AudioSource audioSource;

    void Start()
    {
        // AudioSource 컴포넌트 가져오기
        audioSource = GetComponent<AudioSource>();

        // AudioSource 컴포넌트가 없으면 자동으로 추가
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // AudioSource 기본 설정
        audioSource.playOnAwake = false;
        audioSource.clip = hitSound;
    }

    // EnemyHealth 스크립트에서 데미지를 받을 때 호출될 메서드
    public void PlayHitSound()
    {
        if (audioSource != null && hitSound != null)
        {
            Debug.Log("Sound Playing");
            audioSource.PlayOneShot(hitSound);
        }
    }
}
