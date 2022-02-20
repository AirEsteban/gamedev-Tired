using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffLamp : MonoBehaviour
{
    [SerializeField] Light lamp;
    [SerializeField] float maxTimeToSwitchLight = 0.5f;
    private float initialLampIntensity;
    private float timer = 0.95f;
    private float auxTimer;
    private bool isOn = true;
    
    // Start is called before the first frame update
    void Start()
    {
        auxTimer = timer;
        initialLampIntensity = lamp.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeLampIntensity();
    }

    private void ChangeLampIntensity()
    {
        if(auxTimer > 0)
        {
            auxTimer -= Time.deltaTime;
        }
        else
        {
            if (isOn)
            {
                // We want to turn off the light totally.
                lamp.intensity = 0f;
                isOn = !isOn;
            }
            else
            {
                lamp.intensity = initialLampIntensity;
                isOn = !isOn;
            }
            auxTimer = Random.Range(0f, maxTimeToSwitchLight);
        }
        
    }
}
