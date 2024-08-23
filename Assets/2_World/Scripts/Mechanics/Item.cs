using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class Item : MonoBehaviour
{
    public enum InteractionType { NONE, PickUp, Examine }
    [SerializeField] public InteractionType type;
    [Header("Examine")]
    public string descriptionText;
    [Header("Custom Event")]
    public UnityEvent customEvent;

    public string itemID;

    private void Reset()
    {
        GetComponent<Collider2D>().isTrigger = true;
        gameObject.layer = 10;
    }

    private void Start()
    {
        // 아이템이 이미 획득되었는지 확인하여, 획득되었으면 비활성화
        if (PlayerPrefs.GetInt(itemID, 0) == 1)
        {
            //gameObject.SetActive(false);
        }
    }

    public void Interact()
    {
        switch (type)
        {
            case InteractionType.PickUp:
                // 아이템을 획득 상태로 저장
                PlayerPrefs.SetInt(itemID, 1);
                PlayerPrefs.Save();

                if (itemID == "DoubleJumpItem")
                {
                    PlayerPrefs.SetInt("DoubleJumpEnabled", 1);
                    PlayerPrefs.Save();
                }
                if (itemID == "BulsonShotRedItem")
                {
                    PlayerPrefs.SetInt("BulsonShotRedEnabled", 1);
                    PlayerPrefs.Save();
                }
                if (itemID == "BulsonShotBlueItem")
                {
                    PlayerPrefs.SetInt("BulsonShotBlueEnabled", 1);
                    PlayerPrefs.Save();
                }

                // Add the object to the PickedUpItems list
                FindObjectOfType<InteractionSystem>().PickUpItem(gameObject);
                // Disable
                gameObject.SetActive(false);
                break;
            case InteractionType.Examine:
                // Call the Examine item in the interaction system
                FindObjectOfType<InteractionSystem>().ExamineItem(this);
                break;
            case InteractionType.NONE:
                // NONE 타입에서는 기본적으로 아무것도 하지 않음
                break;
            default:
                // Used for custom event
                break;
        }

        // Invoke the custom event
        customEvent.Invoke();
    }
}
