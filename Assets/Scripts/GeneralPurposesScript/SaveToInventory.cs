using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveToInventory : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
       GameManager.SaveItem(this.gameObject);
       this.gameObject.SetActive(false);
    }
}
