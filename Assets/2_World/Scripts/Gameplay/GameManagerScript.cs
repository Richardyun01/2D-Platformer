using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject gameClearUI;
    public BGMManager bgmManager;

    // Start is called before the first frame update
    void Start()
    {
        /*
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        */
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (gameOverUI.activeInHierarchy)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        */
    }

    public void gameOver()
    {
        gameOverUI.SetActive(true);
        if (bgmManager != null)
        {
            bgmManager.PlayGameOverBGM();
        }
    }

    public void gameClear()
    {
        if (gameClearUI != null) 
        { 
            gameClearUI.SetActive(true);
        }

        if (bgmManager != null)
        {
            bgmManager.PlayGameClearBGM();
        }
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void stageMenu()
    {
        //SceneManager.LoadScene("StageMenu");
        Debug.Log("To Menu");
    }

    public void quit()
    {
        Application.Quit();
    }
}
