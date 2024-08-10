using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGame : MonoBehaviour
{
    public void ExitBtn()
    {
        Debug.Log("Game Exit");
        Application.Quit();
    }
}
