using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class BulsonShotBlue : MonoBehaviour
{
    public PlayerStatus status;
    public PlayerHealth health;

    public int DefenseBonus = 5;
    public bool HpIncreaseing = false;
    public float HpIncreasingValue = 0.5f;

    void Awake()
    {
        // PlayerPrefs에서 BulsonShotRed 아이템 효과 활성화 상태 불러오기
        if (PlayerPrefs.GetInt("BulsonShotBlueEnabled", 0) == 1)
        {
            this.enabled = true;
        }
        else
        {
            this.enabled = false;
        }
    }

    void OnEnable()
    {
        if (status != null)
        {
            status.ModifyStats(0, DefenseBonus, 0, 0);
        }
        HpIncreaseing = true;
    }
    void OnDisable()
    {
        if (status != null)
        {
            status.RevertStats(0, DefenseBonus, 0, 0);
        }
        HpIncreaseing = false;
    }
    void Update()
    {
        if (HpIncreaseing && health.currentHealth < 100)
        {
            health.IncreaseHP(HpIncreasingValue * Time.deltaTime);
            health.UpdateHealthUI();
        }
    }
}
