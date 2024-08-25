using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    public Button yourButton;       // 버튼
    public AudioClip clickSound;    // 클릭 사운드
    private AudioSource audioSource; // 오디오 소스

    void Start()
    {
        if (yourButton == null)
        {
            Debug.LogError("Button is not assigned!");
            return;
        }

        // 오디오 소스 추가 및 설정
        audioSource = gameObject.AddComponent<AudioSource>();
        if (clickSound == null)
        {
            Debug.LogError("AudioClip is not assigned!");
            return;
        }
        audioSource.clip = clickSound;

        // 버튼 클릭 이벤트에 메서드 추가
        yourButton.onClick.AddListener(PlaySound);
    }

    void PlaySound()
    {
        if (audioSource != null)
        {
            Debug.Log("Audio Playing");
            audioSource.Play();
        }
        else
        {
            Debug.LogError("AudioSource is not initialized!");
        }
    }
}


