using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FadeAwayNotif : MonoBehaviour
{    
    private static void FadeAway(TextMeshProUGUI notifText)
    {
        var auxTime = 5000f;
        Debug.Log("fadeaway");
        if(null != notifText)
        {
            Debug.Log("ajsdjopas");
        }
    }

    public static void SetNotificationTextAndSetActive(string text)
    {
        var notifText = GameObject.FindWithTag("NotificationText").GetComponent<TextMeshProUGUI>();
        if (null != notifText)
        {
            notifText.SetText(text);
            notifText.enabled = true;
            notifText.alpha = 1f;
            FadeAway(notifText);
            //notifText.SetText(string.Empty);
        }
        else
        {
            Debug.Log("no encontrado");
        }
    }
}
