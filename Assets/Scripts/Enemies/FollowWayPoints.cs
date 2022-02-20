using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWayPoints : MonoBehaviour
{
    [SerializeField] List<Transform> wayPoints = new List<Transform>();
    [SerializeField] Transform attackedObj;
    [SerializeField] float charSpeed = 2f;
    private int actIndex;
    // Start is called before the first frame update
    void Start()
    {
        actIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        MakeBehaviour();
    }

    private void MakeBehaviour()
    {
        
        var attackedObjPos = attackedObj.position - gameObject.transform.position;
        //Debug.Log("Magnitud: " + nextWp.magnitude);
        //Debug.Log("Magnitud a Player: " + Mathf.Abs(attackedObjPos.magnitude));
        if (Mathf.Abs(attackedObjPos.magnitude) <= 3f)
        {
            Debug.Log("Attack gato attack");
            // play attack animation.
        }
        else
        {
            Debug.Log("Sigo mi camino");
            Follow();
        }
        
    }

    private void Follow()
    {
        var nextWp = wayPoints[actIndex].position - gameObject.transform.position;
        if (nextWp.magnitude > 0.1f)
        {
            gameObject.transform.LookAt(wayPoints[actIndex].position, Vector3.up);
            gameObject.transform.Translate(transform.TransformDirection(nextWp.normalized) * Time.deltaTime * charSpeed, Space.Self);
        }
        else
        {
            actIndex = (actIndex + 1) % wayPoints.Count;
            //Debug.Log("EL PROXIMO INDEX : " + actIndex);
        }
    }
}
