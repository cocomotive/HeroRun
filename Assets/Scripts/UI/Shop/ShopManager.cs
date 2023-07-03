using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;

    public TMP_Text coinUI;
    public List<ShopTemp> buttons;
    public CurrencyManager currencyManager;

    public event System.Action onBuy;

    public void TriggerBuy()
    {
        onBuy?.Invoke();
        coinUI.text = coins.ToString();
    }

    public int coins
    {
        get => currencyManager.coins;
        set => currencyManager.coins = value;
    }

    private void Awake()
    {
        instance = this;
        currencyManager = CurrencyManager.instance;
    }

    private void Start()
    {
        TriggerBuy();
    }

    public void AddCurrency()
    {
        currencyManager.AddCoins();
        TriggerBuy();
    }
}
