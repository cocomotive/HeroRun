using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCheck : MonoBehaviour
{
    public static bool GameEnd = false;
    public GameObject winMenuUI;
    
    
    
    void Win()
    {
        winMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameEnd = true;
    }
}
