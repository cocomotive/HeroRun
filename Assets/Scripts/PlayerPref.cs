using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPref : MonoBehaviour
{
    [SerializeField] int coins;
    int energy;

    public const string PlayerCoins = "PlayerCoins";


    
    public void SaveGame()
    {
        PlayerPrefs.SetInt(PlayerCoins, coins);

        PlayerPrefs.Save();
    }
    
    public void LoadGame()
    {
        coins = PlayerPrefs.GetInt(PlayerCoins);
    }
    
    public void DeleteSave()
    {
        PlayerPrefs.DeleteKey(PlayerCoins);
    }
}
