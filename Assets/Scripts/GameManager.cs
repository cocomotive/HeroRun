using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int coinCurrency;

    public ShopManager shopManager;


    private void Awake()
    {
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
        //instance = this;
    }

    private void Update()
    {
        coinCurrency = shopManager.coins;
    }

    public void SaveGame()
    {
        Serializer.SaveGame(this);
    }

    public void LoadGame()
    {
        GameData data = Serializer.LoadProgress();

        if(data == null)
        {
            coinCurrency = 33;
        }
        else
        {
            coinCurrency = data.coinCurrency;
        }
    }

}
