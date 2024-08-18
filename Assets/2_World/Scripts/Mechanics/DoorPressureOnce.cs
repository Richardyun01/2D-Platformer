using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPressureOnce : MonoBehaviour
{
    public float moveDistance = 3.0f;  // 문이 이동할 거리
    public float moveSpeed = 3.0f;     // 문의 이동 속도

    private Vector3 initialPosition;   // 문의 초기 위치
    private Vector3 openPosition;      // 문이 열렸을 때의 위치
    private bool isOpening = false;    // 문이 열리고 있는지 여부

    void Start()
    {
        // 초기 위치와 열렸을 때의 위치 설정
        initialPosition = transform.position;
        openPosition = initialPosition + new Vector3(0, moveDistance, 0);
    }

    void Update()
    {
        // 문이 열리고 있을 때
        if (isOpening)
        {
            transform.position = Vector3.MoveTowards(transform.position, openPosition, moveSpeed * Time.deltaTime);
            if (transform.position == openPosition)
            {
                isOpening = false;  // 목표 위치에 도달하면 열림을 멈춤
            }
        }
    }

    // 문을 여는 메서드 (한 번만 열리며, 닫히지 않음)
    public void OpenDoor()
    {
        isOpening = true;
    }
}
