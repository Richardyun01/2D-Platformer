using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUIManager : MonoBehaviour
{
    public Image[] itemIcons;  // 아이콘 슬롯을 담을 배열
    private Dictionary<string, Image> itemIconMap = new Dictionary<string, Image>();

    // 일시정지 화면 UI 요소들
    [System.Serializable]
    public class PauseMenuItem
    {
        public string itemID;
        public GameObject iconObject;   // 아이콘 오브젝트
        public Text descriptionText;    // 설명 텍스트
    }
    public PauseMenuItem[] pauseMenuItems;

    private string[] scenesToShow = { "Stage1-1", "Stage1-2", "Stage1-3", "Stage2-1", "Stage2-2", "Stage2-3", "Stage3-1", "Stage3-2", "Stage3-3" };

    void Start()
    {
        // 아이콘을 초기화하고 아이템 상태를 체크합니다.
        InitializeIcons();
        CheckSceneAndUpdateIcons();
        InitializePauseMenuItems();
    }

    void InitializeIcons()
    {
        // 슬롯을 아이템 ID와 매핑합니다.
        itemIconMap.Add("BulsonShotRedItem", itemIcons[0]);
        itemIconMap.Add("DoubleJumpItem", itemIcons[1]);
        itemIconMap.Add("BulsonShotBlueItem", itemIcons[2]);

        // PlayerPrefs를 사용하여 이미 획득된 아이템의 아이콘을 활성화합니다.
        foreach (var itemID in itemIconMap.Keys)
        {
            if (PlayerPrefs.GetInt(itemID, 0) == 1)
            {
                itemIconMap[itemID].gameObject.SetActive(true);
            }
        }
    }

    void InitializePauseMenuItems()
    {
        foreach (var item in pauseMenuItems)
        {
            if (PlayerPrefs.GetInt(item.itemID, 0) == 1)
            {
                item.iconObject.SetActive(true);
                item.descriptionText.gameObject.SetActive(true);
            }
            else
            {
                item.iconObject.SetActive(false);
                item.descriptionText.gameObject.SetActive(false);
            }
        }
    }

    void CheckSceneAndUpdateIcons()
    {
        string currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        if (System.Array.Exists(scenesToShow, scene => scene == currentScene))
        {
            // 해당 씬이라면 아이콘을 보여줍니다.
            foreach (var icon in itemIcons)
            {
                if (icon.gameObject.activeSelf)
                    icon.gameObject.SetActive(true);
            }
        }
        else
        {
            // 해당 씬이 아니라면 아이콘을 숨깁니다.
            foreach (var icon in itemIcons)
            {
                icon.gameObject.SetActive(false);
            }
        }
    }

    public void AddItemIcon(string itemID)
    {
        if (itemIconMap.ContainsKey(itemID))
        {
            itemIconMap[itemID].gameObject.SetActive(true);
        }

        // 일시정지 화면에서도 해당 아이템의 아이콘과 설명을 활성화
        foreach (var item in pauseMenuItems)
        {
            if (item.itemID == itemID)
            {
                item.iconObject.SetActive(true);
                item.descriptionText.gameObject.SetActive(true);
            }
        }
    }

    private void OnEnable()
    {
        // 씬이 변경될 때마다 아이콘 상태를 업데이트
        UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // 씬이 변경될 때마다 아이콘 상태를 업데이트
        UnityEngine.SceneManagement.SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    {
        CheckSceneAndUpdateIcons();
    }
}
