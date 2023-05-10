using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Currency : MonoBehaviour
{
    public int currency;
    public Text currencyText;

    //void Start()
    //{
    //    currencyText.text = currency.ToString();
    //}


    public void LvlComplete()
    {
        currency = currency + 100;
    }





}
