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
    public GameManager gameManager;

    //public const string PlayerCoins = "PlayerCoins";



    private void Start()
    {
        //coinUI.text = coins.ToString();
        LoadPanels();
        CheckPurcheaseable();
    }

    private void Update()
    {
        coinUI.text = coins.ToString();
    }
    public void AddCoins()
    {
        coins = coins + 1000;
        //coinUI.text = coins.ToString();
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
    
    public void LvlComplete()
    {
        coins = coins + 100;
        Debug.Log("+100");
    }
    public void SaveCurrency()
    {
        string save = JsonUtility.ToJson(coins);

        File.WriteAllText(path, save);


        //PlayerPrefs.SetInt(PlayerCoins, coins);

        //PlayerPrefs.Save();
    }

    public void LoadCurrenccy()
    {
        //coins = PlayerPrefs.GetInt(PlayerCoins);





    }

    public void DeleteCurrency()
    {
        
        
        
        //PlayerPrefs.DeleteKey(PlayerCoins);
    }
}
