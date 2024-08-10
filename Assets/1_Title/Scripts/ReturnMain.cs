using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnMain : MonoBehaviour
{
    public void MainBtn()
    {
        Debug.Log("Return Main");
        SceneManager.LoadScene("Main");
    }
}
