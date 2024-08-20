using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AllClear : MonoBehaviour
{
    public void AllClearBtn()
    {
        SceneManager.LoadScene("Clear");
    }
}
