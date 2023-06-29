using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{

    public int goldCurrency;

    public static CurrencyManager instance;

    public ShopManager shopManager;

    public static SaveJson json;

    private void Awake()
    {
        json = SaveJson.instance;
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        //goldCurrency = 10000;
    }

    void Update()
    {
        shopManager = FindObjectOfType<ShopManager>();
        json = FindObjectOfType<SaveJson>();
    }

    public void Discount()
    {
        goldCurrency = shopManager.coins;
        json.SaveGame();
    }


    public void AddCoins()
    {
        goldCurrency = goldCurrency + 1000;// * ItemShop.instance.coinsMult;
        json.SaveGame();
        //coinUI.text = coins.ToString();
    }
    public void LvlComplete()
    {
        goldCurrency = goldCurrency + 100;       
        Debug.Log("+100");
        json.SaveGame();
    }
}
