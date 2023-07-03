using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopTemp : MonoBehaviour
{
    //public TMP_Text titleTxt;
    //public TMP_Text descriptionTxt;


    public TMP_Text title;


    public TMP_Text desc;

    public Image image;

    public TMP_Text costTxt;

    public ShopItem shopItem;

    public Button button;

    ShopManager reference;

    private void Awake()
    {
        costTxt.text = shopItem.baseCost.ToString();

        button.onClick.AddListener(OnClick);

        title.text = shopItem.title;
        desc.text = shopItem.desc;
        image.sprite = shopItem.image;

        
    }

    private void OnEnable()
    {
        reference = ShopManager.instance;

        reference.buttons.Add(this);

        reference.onBuy += Instance_onBuy;
    }

    private void Instance_onBuy()
    {
        button.interactable = reference.coins >= shopItem.baseCost;
    }

    void OnClick()
    {
        ShopManager.instance.coins -= shopItem.baseCost;
        shopItem.Buy();
        button.gameObject.SetActive(false);
        ShopManager.instance.TriggerBuy();
    }

}
