using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPanel : MonoBehaviour
{
    [SerializeField] GameObject panelToActivate;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Graveyard trigger active.");
            panelToActivate.SetActive(true);
            GameManager.instance.isPanelActive = true;
            Destroy(this.gameObject);
        }
        else
        {
            Debug.Log("Graveyard trigger not active.");
        }
    }
}
