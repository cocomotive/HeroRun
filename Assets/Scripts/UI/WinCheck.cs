using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCheck : MonoBehaviour
{
    public GameObject winMenuUI;
    //public Currency currency;

    public void Win()
    {
        winMenuUI.SetActive(true);
        Time.timeScale = 0f;
       //currency.LvlComplete();
    }
}
