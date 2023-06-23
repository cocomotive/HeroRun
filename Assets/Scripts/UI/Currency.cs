using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Currency : MonoBehaviour
{
    public int currency = 1000;
    //public Text currencyText;

    public TMP_Text goldCurrency;
    //public TMP_Text energyCurrency;


    private void Update()
    {
        
        goldCurrency.text = currency.ToString();
    }


    //void Start()
    //{
    //    currencyText.text = currency.ToString();
    //}

    public void LvlComplete()
    {
        currency = currency + 100;
        Debug.Log("+100");
    }

    public void Buy()
    {
        
    }





}
