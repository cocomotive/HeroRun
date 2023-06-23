using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image slider;

    private void Start()
    {
        EventManager.events.SearchOrCreate(EnumUI.life).action += Player_action;
    }    

    private void Player_action(params object[] parameters)
    {
        slider.fillAmount = (float)parameters[0];
    }
}
