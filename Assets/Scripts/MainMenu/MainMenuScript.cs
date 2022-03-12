using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    private float transitionStep;
    private float maxOpacityBound;
    private Color imgColor;
    // Initialize variables
    private void Start()
    {
        var alphaComponent = GetComponent<Image>().color;
        alphaComponent.a = 0;
        GetComponent<Image>().color = alphaComponent;
        maxOpacityBound = 0.95f;
        transitionStep = 0.085f;
        imgColor = GetComponent<Image>().color;

    }
    void Update()
    {
        ChangeOpacity();
    }
     
    // Changing opacity from 0 to maxOpacityBound by transitionStep value
    private void ChangeOpacity()
    {
        
        if(null != imgColor)
        {
            var step = transitionStep * Time.deltaTime;
            if (imgColor.a < maxOpacityBound)
            {
                imgColor.a += step;
            }
            GetComponent<Image>().color = imgColor;
        }
    }
}
