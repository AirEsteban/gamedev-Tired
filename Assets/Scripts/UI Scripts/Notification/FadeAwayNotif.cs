using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FadeAwayNotif : MonoBehaviour
{
    private TMPro.TextMeshProUGUI txtGameOver;
    void Awake()
    {
        Movement.OnDeath += ShowUIAndStopPlaying;
    }

    private void Start()
    {
        txtGameOver = GetComponent<TMPro.TextMeshProUGUI>();
    }

    private static void FadeAway(TextMeshProUGUI notifText)
    {
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
    private void ShowUIAndStopPlaying()
    {
        if(null != txtGameOver)
        {
            Debug.Log("OnDeath Event response from FadeAwayNotif Script");
            txtGameOver.SetText("Game Over!");
            // Just need to stop playing
        }
       
    }
}
