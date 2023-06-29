using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;
using Unity.Notifications.Android;

public class StaminaSystem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI staminaText = null;
    [SerializeField] TextMeshProUGUI staminaTimeText = null;
    
    [SerializeField] int maxStamina = 10;
    [SerializeField] int currentStamina;
    [SerializeField] float timeToCharge = 300f;
    bool recharging;

    DateTime nextStaminaTime;
    DateTime lastStaminaTime;

    public Button[] btts;

    private void Start()
    {
        if (PlayerPrefs.HasKey("currentSamina"))
        {
            Load();
        }
        else
        {
            currentStamina = maxStamina;
            Save();
        }
        UpdateUI();
        StartCoroutine(UpdateStamina());
    }
    public void UseStamina(int staminaToUse)
    {
        if(!HasEnoughStamina(staminaToUse))
        {
                for (int i = 0; i < btts.Length; i++)
                {
                    btts[i].interactable = false;
                }
            Debug.Log("no stamina");
            return;
        }
        currentStamina -= staminaToUse;
        UpdateUI();

        if (currentStamina < maxStamina)
        {
            //NotifSystem.SendNotification(AddDuration(lastStaminaTime, timeToCharge * (maxStamina - currentStamina)),"Energy full, time to play" );
            if (!recharging)
            {
                nextStaminaTime = AddDuration(DateTime.Now, timeToCharge);
                Save();
                StartCoroutine(UpdateStamina());
            }
        }
    }

    DateTime AddDuration(DateTime date, float duration)
    {
        return date.AddSeconds(duration);
    }

    bool HasEnoughStamina(int stamina) => currentStamina >= stamina;

    public void RechargeStamina(int staminaToAdd)
    {
        currentStamina += staminaToAdd;
        UpdateUI();
        Save();
        if (currentStamina >= maxStamina)
        {
            if(recharging )
            {
                recharging = false;
                StopAllCoroutines();
            }
        }
    } 

    IEnumerator UpdateStamina()
    {
        UpdateTimer();
        recharging = true;
        while (currentStamina < maxStamina)
        {
            DateTime currentTime = DateTime.Now;
            DateTime nextTime = nextStaminaTime;
            
            bool addingStamina = false;
            while(currentTime > nextTime)
            {
                if (currentStamina > maxStamina) break;

                currentStamina += 1;
                addingStamina = true;
                DateTime timeToAdd = nextTime;

                if (lastStaminaTime > nextTime)
                    timeToAdd = lastStaminaTime;
                
                nextTime = AddDuration(timeToAdd, timeToCharge);
            }
          
            if(addingStamina)
            {
                nextStaminaTime = nextTime;
                lastStaminaTime = DateTime.Now;
            }

            UpdateUI();
            UpdateTimer();
            Save();
            yield return new WaitForEndOfFrame();
        }
        recharging = false;
    }

    void UpdateTimer()
    {
        if (currentStamina >= maxStamina)
        {
            staminaTimeText.text = "FULL";
            return;
        }
        TimeSpan timer = nextStaminaTime - DateTime.Now;

        staminaTimeText.text = timer.Minutes.ToString("00") + ":" + timer.Seconds.ToString("00");
        
    }
    void UpdateUI()
    {
        staminaText.text = currentStamina.ToString() + "/" + maxStamina.ToString();
    }

    void Save()
    {
        PlayerPrefs.SetInt("currentSamina", currentStamina);
        PlayerPrefs.SetString("nextStaminaTime", nextStaminaTime.ToString());
        PlayerPrefs.SetString("lastStaminaTime", lastStaminaTime.ToString());
    }

    void Load()
    {
        currentStamina = PlayerPrefs.GetInt("currentSamina");
        nextStaminaTime = StringToDateTime(PlayerPrefs.GetString("nextStaminaTime"));
        lastStaminaTime = StringToDateTime(PlayerPrefs.GetString("lastStaminaTime"));
    }

    DateTime StringToDateTime(string date)
    {
        if(string.IsNullOrEmpty(date))
        {
            return DateTime.Now;
        }
        return DateTime.Parse(date);
    }
}
