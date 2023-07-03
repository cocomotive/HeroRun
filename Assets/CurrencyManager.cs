using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    [SerializeField]
    int _coins;

    public int coins
    {
        get => _coins;
        set
        {
            _coins = value;

            json.SaveGame();
        }
    }

    public static CurrencyManager instance;

    public static SaveJson json;

    private void Awake()
    {
        json = SaveJson.instance;
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddCoins()
    {
        coins += 1000 * ItemShop.instance.coinsMult;
    }

    public void LvlComplete()
    {
        coins += 100;
    }
}
