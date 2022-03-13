using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public enum Scenes { MAINMENUSCENE = 0, FIRSTLEVEL};
public class BtnScripts : MonoBehaviour, IPointerEnterHandler
{
    private AudioSource audioSrc;
    [SerializeField] AudioClip clickClip;
    [SerializeField] AudioClip hoverClip;
    private void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (null != audioSrc)
        {
            audioSrc.PlayOneShot(hoverClip);
        }
    }

    public void LoadFirstLevel()
    {
        if (null != audioSrc)
        {
            audioSrc.PlayOneShot(clickClip);
        }
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        if (null != audioSrc)
        {
            audioSrc.PlayOneShot(clickClip);
        }
        Application.Quit();
    }
}
