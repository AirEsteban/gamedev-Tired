using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePanel : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && GameManager.instance.isPanelActive)
        {
            this.gameObject.SetActive(false);
            GameManager.instance.isPanelActive = false;
        }
    }
}
