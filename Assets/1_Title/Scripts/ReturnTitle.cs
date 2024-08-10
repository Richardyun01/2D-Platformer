using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnTitle : MonoBehaviour
{
    public void TitleBtn()
    {
        Debug.Log("Return Title");
        SceneManager.LoadScene("Title");
    }
}
