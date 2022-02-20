using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWayPoints : MonoBehaviour
{
    [SerializeField] List<Transform> wayPoints = new List<Transform>();
    [SerializeField] Transform attackedObj;
    [SerializeField] float charSpeed = 2f;
    [SerializeField] Animator anim;
    private int actIndex;
    // Start is called before the first frame update
    void Start()
    {
        actIndex = 0;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MakeBehaviour();
    }

    private void MakeBehaviour()
    {
        anim.SetBool("walk", true);
        var attackedObjPos = attackedObj.position - gameObject.transform.position;
        if (Mathf.Abs(attackedObjPos.magnitude) <= 3f)
        {
            anim.SetBool("walk", false);
            anim.SetBool("attack", true);
            //gameObject.transform.LookAt(attackedObj.transform.position, Vector3.up);
            //Debug.Log("Attack gato attack");
        }
        else
        {
            //Debug.Log("Sigo mi camino");
            Follow();
        }
        
    }

    private void Follow()
    {
        var nextWp = wayPoints[actIndex].position - gameObject.transform.position;
        anim.SetBool("attack", false);
        anim.SetBool("walk", true);
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
