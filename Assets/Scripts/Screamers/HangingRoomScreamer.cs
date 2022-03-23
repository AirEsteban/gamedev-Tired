using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HangingRoomScreamer : MonoBehaviour
{
    [SerializeField] float rayLength = 4f;

    [SerializeField] public UnityEvent OnHangingRoomEnter;
    void Update()
    {
        CastRay();
    }

    private void CastRay()
    {
        var ray = new Ray(transform.position, transform.forward * rayLength);
        var rayHit = new RaycastHit();
        Debug.DrawRay(this.transform.position, transform.forward * rayLength, Color.blue);
        if (Physics.Raycast(ray, out rayHit))
        {
            if (rayHit.collider.CompareTag("Player"))
            {
                Debug.Log("OnHangingRoomEnter event invoked by HangingRoom RayCast.");
                OnHangingRoomEnter?.Invoke();
                Destroy(this);
            }
        }
    }
}
