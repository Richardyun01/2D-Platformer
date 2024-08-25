using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance = null;
    public AudioSource bgmAudioSource;

    void Awake()
    {
        // Singleton 패턴 구현: 이미 인스턴스가 존재하면 파괴하고, 그렇지 않으면 유지
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // 씬이 변경될 때마다 OnSceneLoaded를 호출
        SceneManager.sceneLoaded += OnSceneLoaded;

        // 시작 시 씬에 맞는 BGM 재생
        PlayBGMIfNeeded(SceneManager.GetActiveScene().name);
    }

    // 씬이 로드될 때마다 호출되는 함수
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayBGMIfNeeded(scene.name);
    }

    // 특정 씬에서만 BGM을 재생하는 함수
    private void PlayBGMIfNeeded(string sceneName)
    {
        if (sceneName == "Title" || sceneName == "Main" || sceneName == "Level1" || sceneName == "Level2" || sceneName == "Level3")
        {
            if (!bgmAudioSource.isPlaying)
            {
                bgmAudioSource.Play();
            }
        }
        else
        {
            if (bgmAudioSource.isPlaying)
            {
                bgmAudioSource.Stop();
            }
        }
    }
}
