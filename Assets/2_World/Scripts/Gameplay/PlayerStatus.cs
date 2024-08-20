using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public float Attack = 5f;
    public float Defense = 0f;
    public float Player_Attack_Scale = 1f;
    public float Player_AttackTaken_Scale = 1f;

    public float Weapon_Attack;
    public float Enemy_Defense;
    void Start()
    {

    }

    void Update()
    {
        //player's final attack damage
        float Player_Damage = (Attack * Weapon_Attack - Enemy_Defense) * Player_Attack_Scale;
    }

    public void ModifyStats(int AttackModifier, int DefenseModifier, float AttackScaleModifier, float AttackTakenScaleModifier)
    {
        Attack += AttackModifier;
        Defense += DefenseModifier;
        Player_Attack_Scale += AttackScaleModifier;
        Player_AttackTaken_Scale += AttackTakenScaleModifier;
    }
    public void RevertStats(int AttackModifier, int DefenseModifier, float AttackScaleModifier, float AttackTakenScaleModifier)
    {
        Attack -= AttackModifier;
        Defense -= DefenseModifier;
        Player_Attack_Scale -= AttackScaleModifier;
        Player_AttackTaken_Scale -= AttackTakenScaleModifier;
    }
}
