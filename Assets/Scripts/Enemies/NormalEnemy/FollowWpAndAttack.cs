using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWpAndAttack : MonoBehaviour
{
    // Game objects
    [SerializeField] ScriptableNormalEnemy enemyData;
    [SerializeField] GameObject attackPoint;
    [SerializeField] GameObject bullet;

    // Transform Properties
    [SerializeField] List<Transform> wayPoints = new List<Transform>();
    public Transform attackedObj;

    // Auxiliar properties
    [SerializeField] bool doesAttack = true;
    private float auxTimeToAttack = 0f;
    private Animator anim;
    private int actIndex;
    public bool canAttack = false;


    // Start is called before the first frame update
    void Start()
    {
        actIndex = 0;
        anim = GetComponent<Animator>();
        auxTimeToAttack = enemyData.timeToAttack;
        enemyData.enemyLife = 120f;
    }

    // Update is called once per frame
    void Update()
    {
        if (doesAttack)
        {
            MakeBehaviour();
        }
        else
        {
            FollowWp();
        }
        
    }

    private void MakeBehaviour()
    {
        anim.SetBool("walk", true);
        var attackedObjPos = attackedObj.position - gameObject.transform.position;
        if (Mathf.Abs(attackedObjPos.magnitude) <= 5f)
        {

            var charRot = Quaternion.LookRotation(attackedObjPos, Vector3.up);
            transform.localRotation = Quaternion.Lerp(transform.rotation, charRot, enemyData.charSpeedRotation * Time.deltaTime);
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
            transform.rotation = Quaternion.Lerp(transform.rotation, newRot, enemyData.charSpeedRotation * Time.deltaTime);
            gameObject.transform.Translate(transform.TransformDirection(nextWp.normalized) * Time.deltaTime * enemyData.charSpeed, Space.Self);
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
            projectile.GetComponent<Rigidbody>().AddForce(attackedObjPos.normalized * enemyData.bulletSpeed, ForceMode.Impulse);
            
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
                auxTimeToAttack = enemyData.timeToAttack;
            }
        }
    }

    public void TakeDmg(float dmg)
    {
        enemyData.enemyLife -= dmg;
        if(enemyData.enemyLife <= 0)
        {
            Destroy(this.gameObject);
        }
    }

}
