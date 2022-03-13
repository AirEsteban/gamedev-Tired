using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnterNotification : MonoBehaviour
{
    [SerializeField] string notificationText;
    private void OnTriggerEnter(Collider other)
    {
        //FadeAwayNotif.SetNotificationTextAndSetActive(notificationText);
    }
}
