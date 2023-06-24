using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ShopManager : MonoBehaviour
{
    public int coins;
    public TMP_Text coinUI;
    public ShopItem[] shopItems;
    public ShopTemp[] shopPanels;
    public Button[] myPurchaseBt;


    private void Start()
    {
        coinUI.text = coins.ToString();
        LoadPanels();

        CheckPurcheaseable();
    }


    public void AddCoins()
    {
        coins = coins + 1000;
        coinUI.text = coins.ToString();
        CheckPurcheaseable();
    }

    public void CheckPurcheaseable()
    {
        for (int i = 0; i < shopItems.Length; i++)
        {
            if (coins >= shopItems[i].baseCost)
            {
                myPurchaseBt[i].interactable = true;
            }
            else
            {
                myPurchaseBt[i].interactable = false;
            }
        }
    }

    public void LoadPanels()
    {
        for (int i = 0; i < shopItems.Length; i++)
        {
            //shopPanels[i].titleTxt.text = shopItems[i].title;
            //shopPanels[i].descriptionTxt.text = shopItems[i].description;
            shopPanels[i].costTxt.text = shopItems[i].baseCost.ToString();
        }
    }

    public void PurchaseItem(int btNm)
    {
        if(coins >= shopItems[btNm].baseCost)
        {
            coins = coins - shopItems[btNm].baseCost;
            coinUI.text = coins.ToString();
            CheckPurcheaseable();
            myPurchaseBt[btNm].gameObject.SetActive(false);
        }
    }
}
