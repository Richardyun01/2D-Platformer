using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stage33 : MonoBehaviour
{
    public Button stageButton; // 버튼 UI
    public Sprite lockedSprite; // 잠겨 있는 상태의 스프라이트
    public Sprite unlockedSprite; // 잠금 해제 상태의 스프라이트
    private Image buttonImage; // 버튼의 이미지 컴포넌트

    private void Start()
    {
        buttonImage = stageButton.GetComponent<Image>();
        int previousStageCleared = PlayerPrefs.GetInt("Stage32Cleared", 0); // 이전 스테이지가 클리어되었는지 확인

        if (previousStageCleared == 1)
        {
            stageButton.interactable = true; // 버튼 활성화
            buttonImage.sprite = unlockedSprite;
        }
        else
        {
            //spriteRenderer.color = new Color(1, 1, 1, 0.4f);
            stageButton.interactable = false; // 버튼 비활성화
            buttonImage.sprite = lockedSprite;
        }
    }

    public void Stage33Btn()
    {
        SceneManager.LoadScene("Stage3-3");
    }
}
