using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum AudioOnOff { ON = 0, OFF = 1};
public class MainMenuScript : MonoBehaviour
{
    private float transitionStep;
    private float maxOpacityBound;
    private Color imgColor;
    private bool speakerVisible;
    [SerializeField] GameObject[] speakersImg = new GameObject[2];
    private AudioSource audioSrc;
    // Initialize variables
    private void Start()
    {
        var alphaComponent = GetComponent<Image>().color;
        alphaComponent.a = 0;
        GetComponent<Image>().color = alphaComponent;
        maxOpacityBound = 0.95f;
        transitionStep = 0.085f;
        imgColor = GetComponent<Image>().color;
        speakerVisible = true;
        audioSrc = GetComponent<AudioSource>();
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

    public void MusicOnOff()
    {
        speakersImg[(int)AudioOnOff.ON].SetActive(speakerVisible);
        speakersImg[(int)AudioOnOff.OFF].SetActive(!speakerVisible);
        speakerVisible = !speakerVisible;
        if (speakerVisible && null != audioSrc)
        {
            audioSrc.Play();
        }

        if(!speakerVisible && null != audioSrc)
        {
            audioSrc.Stop();
        }
    }
}
