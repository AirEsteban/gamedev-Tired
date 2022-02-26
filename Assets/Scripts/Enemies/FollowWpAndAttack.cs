using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWpAndAttack : MonoBehaviour
{
    // Character properties
    [SerializeField] float charSpeed = 2f;
    [SerializeField] float charSpeedRotation = 4.2f;
    [SerializeField] GameObject attackPoint;
    [SerializeField] bool canAttack = false;
    [SerializeField] float timeToAttack = 0.85f;
    private float auxTimeToAttack = 0f;
    // Transform Properties
    [SerializeField] List<Transform> wayPoints = new List<Transform>();
    public Transform attackedObj;
    // Animator Properties
    protected Animator anim;
    // Auxiliar Properties
    private int actIndex;
    // Bullet GameObject
    [SerializeField] GameObject bullet;
    [SerializeField] float bulletSpeed = 7f;


    // Start is called before the first frame update
    void Start()
    {
        actIndex = 0;
        anim = GetComponent<Animator>();
        auxTimeToAttack = timeToAttack;
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
        if (Mathf.Abs(attackedObjPos.magnitude) <= 5f)
        {
            var charRot = Quaternion.LookRotation(attackedObjPos, Vector3.up);
            transform.localRotation = Quaternion.Lerp(transform.rotation, charRot, charSpeedRotation * Time.deltaTime);
            if (transform.localRotation.w <= 0.2f)
            {
                anim.SetBool("walk", false);
                Attack(attackedObjPos, anim);
            }
            
        }
        else
        {
            FollowWp();
        }
        
    }

    private void FollowWp()
    {
        var nextWp = wayPoints[actIndex].position - gameObject.transform.position;
        anim.SetBool("attack", false);
        anim.SetBool("walk", true);
        if (nextWp.magnitude > 0.1f)
        {
            var newRot = Quaternion.LookRotation(nextWp, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, newRot, charSpeedRotation * Time.deltaTime);
            gameObject.transform.Translate(transform.TransformDirection(nextWp.normalized) * Time.deltaTime * charSpeed, Space.Self);
        }
        else
        {
            actIndex = (actIndex + 1) % wayPoints.Count;
        }
    }

    private void Attack(Vector3 attackedObjPos, Animator anim)
    {
        if (canAttack)
        {
            anim.SetBool("attack", true);
            var projectile = Instantiate(bullet, attackPoint.transform.position, Quaternion.identity);
            projectile.transform.localRotation = transform.localRotation;
            projectile.GetComponent<Rigidbody>().AddForce(attackedObjPos.normalized * bulletSpeed, ForceMode.Impulse);
            
            canAttack = false;
        }
        else
        {
            if (auxTimeToAttack > 0f)
            {
                auxTimeToAttack -= Time.deltaTime;
            }
            else
            {
                canAttack = true;
                auxTimeToAttack = timeToAttack;
            }
        }
    }

}
