using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPanel : MonoBehaviour
{
    [SerializeField] GameObject panelToActivate;
    private void OnTriggerEnter(Collider other)
    {
        panelToActivate.SetActive(true);
        GameManager.instance.isPanelActive = true;
        Destroy(this.gameObject);
    }
}
