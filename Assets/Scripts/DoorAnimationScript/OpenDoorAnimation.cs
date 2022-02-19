using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorAnimation : MonoBehaviour
{
    [SerializeField] Animator anim;
    private float timerToIdle = 2f;
    private float auxTimer;
    void Start()
    {
        auxTimer = timerToIdle;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (auxTimer <= 0f)
        {
            anim.SetBool("openDoor", false);
        }
        else
        {   
            auxTimer -= Time.deltaTime;
        }
        anim.SetBool("openDoor", true);
    }
}
