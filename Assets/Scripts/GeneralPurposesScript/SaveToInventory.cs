using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveToInventory : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.GotItuRustKey = true;
            this.gameObject.SetActive(false);
        }
       
    }
}
