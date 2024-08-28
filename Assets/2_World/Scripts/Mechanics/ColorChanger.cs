using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColorChanger : MonoBehaviour
{
    // 커스텀 이벤트 정의, Color를 인자로 받음
    [System.Serializable]
    public class ColorChangeEvent : UnityEvent<Color> { }

    // 이벤트 인스턴스 생성
    public ColorChangeEvent onColorChange;

    // 색상 변경 메서드
    public void ChangeColor(Color newColor)
    {
        // Renderer를 통해 오브젝트의 색상 변경
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = newColor;
        }

        // 이벤트 호출
        onColorChange.Invoke(newColor);
    }
}

