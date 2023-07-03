using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShop : MonoBehaviour
{
    public static ItemShop instance;

    public int coinsMult = 1;

    public float damageMult = 1;

    public float enemyDmgMult = 1;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance.gameObject);
        }        

        instance = this;        
        DontDestroyOnLoad(this);        
    }
}
