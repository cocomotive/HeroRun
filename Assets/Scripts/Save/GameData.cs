using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{

    public int coinCurrency;
    
    public GameData(GameManager gameProgress)
    {
        coinCurrency = gameProgress.coinCurrency;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
