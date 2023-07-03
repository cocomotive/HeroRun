using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "shopMenu", menuName = "ScriptableObjects/New shop Item", order = 1)]
public class ShopItem : ScriptableObject
{
    [Header("descripcion")]
    [TextArea]
    public string title;

    [TextArea(3, 6)]
    public string desc;

    public Sprite image;

    [Header("Costo:")]

    public int baseCost;

    [Header("Multiplicadores")]

    public int coinsMult = 0;

    public float damageMult = 0;

    public float enemyDmgMult = 0;

    public void Buy()
    {
        ItemShop.instance.coinsMult += coinsMult;
        ItemShop.instance.damageMult += damageMult;
        ItemShop.instance.enemyDmgMult += enemyDmgMult;
    }
}
