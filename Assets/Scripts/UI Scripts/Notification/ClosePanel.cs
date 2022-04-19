using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClosePanel : MonoBehaviour
{
    [SerializeField] public UnityEvent OnClosePanel;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && GameManager.instance.isPanelActive)
        {
            this.gameObject.SetActive(false);
            GameManager.instance.isPanelActive = false;
            OnClosePanel.Invoke();
        }
    }
}
