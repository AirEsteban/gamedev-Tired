using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Keys { ItuKey = 1, ExitKey = 2 };
public class SaveToInventory : MonoBehaviour
{
    [SerializeField] public UnityEvent OnPickUpKey;
    [SerializeField] public UnityEvent<Transform> OnPickUpKeyScreamer;
    [SerializeField] public Transform lookAtObject;
    [SerializeField] public Keys keyType;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (keyType == Keys.ItuKey)
            {
                GameManager.instance.gotItuRustKey = true;
            }
            if (keyType == Keys.ExitKey)
            {
                GameManager.instance.gotExitKey = true;
            }
            
            Debug.Log("OnPickUpKey Unity Event sent by" + this.gameObject.name + " object");
            OnPickUpKey?.Invoke();
            OnPickUpKeyScreamer?.Invoke(lookAtObject);
            this.gameObject.SetActive(false);
        }
    }
}
