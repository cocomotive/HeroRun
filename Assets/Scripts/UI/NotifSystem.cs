using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;
using System;

public class NotifSystem : MonoBehaviour
{




    private void Awake()
    {
        AndroidNotificationCenter.CancelAllDisplayedNotifications();

        var channel = new AndroidNotificationChannel("renergy_notif_channel", "energy full notification", "make the user play", Importance.High);
        AndroidNotificationCenter.RegisterNotificationChannel(channel);
        
        
        var notification = new AndroidNotification();
        notification.Title = "Energy full, time to play";
        //notification.FireTime = DateTime.Now.();
        notification.RepeatInterval = TimeSpan.FromHours(1);


        AndroidNotificationCenter.SendNotification(notification, channel.Id);
    }

    public static void SendNotification(DateTime schedule, string title)
    {
        var notification = new AndroidNotification();
        notification.Title = title;
        notification.FireTime = schedule;
        notification.RepeatInterval = TimeSpan.FromHours(1);


        AndroidNotificationCenter.SendNotification(notification, "renergy_notif_channel");
    }
}
