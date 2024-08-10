using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClear : MonoBehaviour
{
    public GameManagerScript gameManager;
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Debug.Log("Game Cleared");
            player.SetActive(false);
            if (gameManager != null)
            {
                gameManager.gameClear();
            }
            else
            {
                Debug.LogError("GameManagerScript is not assigned.");
            }
        }
    }
}
