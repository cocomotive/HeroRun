using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShop : MonoBehaviour
{
    public static ItemShop instance;

    public float coinsMult = 1;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }        
        instance = this;        
        DontDestroyOnLoad(this);        
    }


}
