using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerColorChange : MonoBehaviour
{
    public ColorChanger colorChanger; // ColorChanger 스크립트를 참조
    public Color targetColor = Color.red; // 변경할 색상 설정

    void Update()
    {
        // 스페이스바를 누르면 색상 변경
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (colorChanger != null)
            {
                colorChanger.ChangeColor(targetColor);
            }
        }
    }
}

