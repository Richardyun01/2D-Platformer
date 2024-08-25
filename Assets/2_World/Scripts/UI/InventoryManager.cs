using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    // 획득한 아이템 목록
    private List<Item> pickedUpItems = new List<Item>();

    // UI 패널에 표시할 부모 오브젝트와 UI 프리팹
    public GameObject inventoryPanel;
    public GameObject itemUIPrefab;

    private void Awake()
    {
        // Singleton 패턴을 사용하여 인스턴스를 유지
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // 아이템을 추가하고 UI에 표시
    public void AddItem(Item item)
    {
        if (!pickedUpItems.Contains(item))
        {
            pickedUpItems.Add(item);
            UpdateInventoryUI(item);
        }
    }

    // 획득한 아이템을 UI에 표시
    private void UpdateInventoryUI(Item item)
    {
        GameObject newItemUI = Instantiate(itemUIPrefab, inventoryPanel.transform);
        Image itemImage = newItemUI.GetComponent<Image>();
        Text itemDescription = newItemUI.GetComponentInChildren<Text>();

        // 아이템의 스프라이트와 설명을 UI에 반영
        itemImage.sprite = item.GetComponent<SpriteRenderer>().sprite;
        itemDescription.text = item.descriptionText;
    }

    // 씬이 로드될 때 이전에 획득한 아이템을 다시 표시
    private void Start()
    {
        foreach (var item in pickedUpItems)
        {
            UpdateInventoryUI(item);
        }
    }
}

