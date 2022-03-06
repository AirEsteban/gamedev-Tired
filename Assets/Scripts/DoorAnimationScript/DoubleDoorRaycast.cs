using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class DoubleDoorRaycast : MonoBehaviour
{
    [SerializeField] float rayDistance = 7f;
    private Ray rayCast;
    private PlayableDirector timeLine;
    private bool doorOpened;
    [SerializeField] string requiredKeyTag;
    // Start is called before the first frame update
    private void Start()
    {
        doorOpened = false;
        timeLine = this.GetComponentInParent<PlayableDirector>();
    }
    void Update()
    {
        CastRay();
        var hitInfo = new RaycastHit();
        if(Physics.Raycast(rayCast, out hitInfo))
        {
            if (hitInfo.collider != null)
            {
                if (hitInfo.collider.gameObject.CompareTag("Player") 
                    && !doorOpened 
                    && GameManager.instance.get)
                {
                    timeLine.Play(timeLine.playableAsset);
                }
            }
        }
    }

    private void CastRay()
    {
        var rayCastPoint = this.transform.Find("RayCastPoint");
        var rayDir = transform.forward * rayDistance;
        rayCast = new Ray(rayCastPoint.position, rayDir);
    }
}
