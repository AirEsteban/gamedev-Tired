using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UpgradedRayCast : MonoBehaviour
{
    [SerializeField] float rayDistance = 4.5f;
    private float rayAngleCoef = 0.25f;
    private Ray[] rays = new Ray[3];
    // Update is called once per frame

    protected enum RayDirection { Front = 0, Left = 1, Right = 2 }
    void Update()
    {
        CastRay();
    }
    private void CastRay()
    {
        var changedCoef = (transform.right * rayAngleCoef);
        var frontRay = transform.forward * rayDistance;
        var leftFrontRay = (transform.forward + changedCoef).normalized * rayDistance;
        var rightFrontRay = (transform.forward - changedCoef).normalized * rayDistance;

        rays[(int)RayDirection.Front] = new Ray(transform.position, frontRay);
        rays[(int)RayDirection.Left] = new Ray(this.transform.position, leftFrontRay);
        rays[(int)RayDirection.Right] = new Ray(this.transform.position, rightFrontRay);

        Debug.DrawRay(this.transform.position, frontRay, Color.blue);
        Debug.DrawRay(this.transform.position, leftFrontRay, Color.red);
        Debug.DrawRay(this.transform.position, rightFrontRay, Color.yellow);

        /**var hitFront = new RaycastHit();
        var hitLeft = new RaycastHit();
        var hitRight = new RaycastHit();

        if(Physics.Raycast(rays[(int)RayDirection.Front], out hitFront) 
            || Physics.Raycast(rays[(int)RayDirection.Left], out hitLeft) 
            || Physics.Raycast(rays[(int)RayDirection.Right], out hitRight))
        {
            var gObjFront = hitFront.collider.gameObject;
            var gObjLeft = hitLeft.collider.gameObject;
            var gObjRight = hitRight.collider.gameObject;
            if (gObjFront.CompareTag("Player") || gObjLeft.CompareTag("Player") || gObjRight.CompareTag("Player"))
            {
                Debug.Log("Now I see You");
            }
        }*/
    }
}
