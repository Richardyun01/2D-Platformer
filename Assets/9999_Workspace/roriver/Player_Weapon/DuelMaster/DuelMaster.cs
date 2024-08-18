using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuelMaster : MonoBehaviour
{
    public PlayerStatus status;

    public float AttackScaleBonus = 0.5f;
    public float AttackTakenScaleBonus = 0.5f;

    void OnEnable()
    {
        if (status != null)
        {
            status.ModifyStats(0, 0, AttackScaleBonus, AttackTakenScaleBonus);
        }
    }
    void OnDisable()
    {
        if (status != null)
        {
            status.RevertStats(0, 0, AttackScaleBonus, AttackTakenScaleBonus);
        }
    }
}
