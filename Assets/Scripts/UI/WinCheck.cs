using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCheck : MonoBehaviour
{
    public GameObject winMenuUI;
    public CurrencyManager currencyManager;

    public void Win()
    {
        winMenuUI.SetActive(true);
        Time.timeScale = 0f;
        currencyManager.LvlComplete();
    }
}
