using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public DoorPressure doorPressure; // 자동문 스크립트 참조
    public GameObject platform;
    public string targetTagPlayer = "Player"; // 플레이어나 특정 블록의 태그
    public string targetTagBlock = "MovableBlock";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(targetTagPlayer) || other.CompareTag(targetTagBlock))
        {
            if (doorPressure != null)
            {
                doorPressure.OpenDoor();
            }
            if (platform != null)
            {
                platform.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(targetTagPlayer) || other.CompareTag(targetTagBlock))
        {
            if (doorPressure != null)
            {
                doorPressure.CloseDoor();
            }
            if (platform != null)
            {
                platform.SetActive(false);
            }
        }
    }
}
