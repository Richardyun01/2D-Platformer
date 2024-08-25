using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public float Attack = 5f;
    public float Defense = 0f;
    public float Player_Attack_Scale = 1f;
    public float Player_AttackTaken_Scale = 1f;

    public float Weapon_Attack;
    public float Enemy_Defense;

    public Text attackText;
    public Text defenceText;

    void Start()
    {
        UpdateAttackUI();
        UpdateDefenceUI();
    }

    public void UpdateAttackUI()
    {
        attackText.text = "- 현재 공격력: " + Attack.ToString();
    }

    public void UpdateDefenceUI()
    {
        defenceText.text = "- 현재 방어력: " + Defense.ToString();
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
