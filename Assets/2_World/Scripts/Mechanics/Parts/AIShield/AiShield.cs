﻿using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiShleid : MonoBehaviour
{
    float Speed_reduction = 0.5f;
    float Damage_reduction = 0.5f;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            PlayerController playerController = GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.maxSpeed *= Speed_reduction;
                Debug.Log("방패 On");
            }
            PlayerStatus status = GetComponent<PlayerStatus>();
            if(status != null )
            {
                status.Player_AttackTaken_Scale *= Damage_reduction;
            }
        }
        if (Input.GetMouseButtonUp(1))
        {
            PlayerController playerController = GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.maxSpeed /= Speed_reduction;
                Debug.Log("방패 Off");
            }
            PlayerStatus status = GetComponent<PlayerStatus>();
            if (status != null)
            {
                status.Player_AttackTaken_Scale /= Damage_reduction;
            }
        }
    }
}
