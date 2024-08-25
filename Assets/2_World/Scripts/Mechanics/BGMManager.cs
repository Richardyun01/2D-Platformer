using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public AudioSource bgmSource;         // 현재 BGM을 재생하는 AudioSource
    public AudioClip gameOverBGM;         // 게임 오버 시 재생할 BGM
    public AudioClip gameClearBGM;         // 게임 오버 시 재생할 BGM

    void Start()
    {
        // AudioSource가 설정되어 있는지 확인
        if (bgmSource == null)
        {
            bgmSource = GetComponent<AudioSource>();
        }
    }

    // BGM을 종료하고 새로운 BGM을 재생하는 메서드
    public void PlayGameOverBGM()
    {
        if (bgmSource != null && gameOverBGM != null)
        {
            bgmSource.Stop();                 // 현재 BGM 종료
            bgmSource.loop = false;           // 반복 재생 끄기
            bgmSource.clip = gameOverBGM;     // 게임 오버 BGM 설정
            bgmSource.Play();                 // 새로운 BGM 재생
        }
    }

    public void PlayGameClearBGM()
    {
        if (bgmSource != null && gameClearBGM != null)
        {
            bgmSource.Stop();                 // 현재 BGM 종료
            bgmSource.loop = false;           // 반복 재생 끄기
            bgmSource.clip = gameClearBGM;     // 게임 오버 BGM 설정
            bgmSource.Play();                 // 새로운 BGM 재생
        }
    }
}
