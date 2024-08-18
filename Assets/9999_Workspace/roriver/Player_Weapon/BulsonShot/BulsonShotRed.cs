using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulsonShotRed : MonoBehaviour
{
    public PlayerStatus status;

    public int AttackBonus = 5;

    void OnEnable()
    {
        if(status != null)
        {
            status.ModifyStats(AttackBonus,0,0,0);
        }
    }
    void OnDisable()
    {
        if (status != null)
        {
            status.RevertStats(AttackBonus,0,0,0);
        }
    }
}
