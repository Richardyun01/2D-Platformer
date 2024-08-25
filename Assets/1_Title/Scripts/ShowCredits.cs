using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCredits : MonoBehaviour
{
    // 크레딧 화면이 담긴 패널을 연결하기 위한 public 변수
    public GameObject creditsPanel;

    // 크레딧 화면을 보여주는 함수
    public void ShowCreditsPanel()
    {
        creditsPanel.SetActive(true); // 크레딧 화면 활성화
    }

    // 크레딧 화면을 숨기는 함수
    public void HideCreditsPanel()
    {
        creditsPanel.SetActive(false); // 크레딧 화면 비활성화
    }
}

