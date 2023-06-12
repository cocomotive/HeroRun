using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{

    [SerializeField] ShopItem[] myItems;

   // [SerializeField] ShopButton buttonPrefab = null;
    
    void Start()
    {
        for(int i = 0; i >= myItems.Length; i++)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
