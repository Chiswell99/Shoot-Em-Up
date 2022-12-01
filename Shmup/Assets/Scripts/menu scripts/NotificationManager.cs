using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;
using System;

public class NotificationManager : MonoBehaviour
{
    
    void Start()
    {
        AndroidNotificationCenter.CancelAllDisplayedNotifications();

        var channel = new AndroidNotificationChannel()
        {
            Id = "Channel_Shmup",
            Name = "Shmup Game",
            Importance = Importance.Default,
            Description = "Generic notifications",
        };

        AndroidNotificationCenter.RegisterNotificationChannel(channel);

        var play_notification = new AndroidNotification();
        play_notification.Title = "Es hora de volver a jugar!!!";
        play_notification.Text = "Capitan, su nave le espera para continuar su aventura!";
        play_notification.FireTime = DateTime.Now.AddSeconds(20);

        var id = AndroidNotificationCenter.SendNotification(play_notification, "Channel_Shmup");

        if (AndroidNotificationCenter.CheckScheduledNotificationStatus(id) == NotificationStatus.Scheduled)
        {
            AndroidNotificationCenter.CancelAllNotifications();
            AndroidNotificationCenter.SendNotification(play_notification, "Channel_Shmup");
        }
    }

}

    

