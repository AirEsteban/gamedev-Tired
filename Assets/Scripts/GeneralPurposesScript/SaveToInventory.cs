using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SaveToInventory : MonoBehaviour
{
    [SerializeField] public UnityEvent OnPickUpKey;
    [SerializeField] public UnityEvent<Transform> OnPickUpKeyScreamer;
    [SerializeField] public Transform lookAtObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.gotItuRustKey = true;
            Debug.Log("OnPickUpKey Unity Event sent by" + this.gameObject.name + " object");
            OnPickUpKey?.Invoke();
            OnPickUpKeyScreamer?.Invoke(lookAtObject);
            this.gameObject.SetActive(false);
        }
    }
}
