using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradedAttack : MonoBehaviour
{
    [SerializeField] Transform[] attPoints = new Transform[6];
    [SerializeField] float timeToAttack;
    [SerializeField] GameObject bullet;
    [SerializeField] float bulletSpeed;
    private float playAnimationTime = 5f;
    private float auxPlayAnimation;
    private float auxTimeToAttack;

    private void Start()
    {
        auxTimeToAttack = timeToAttack;
        auxPlayAnimation = playAnimationTime;
    }
    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    private void Attack()
    {
        if(auxPlayAnimation > 0f)
        {
            auxPlayAnimation -= Time.deltaTime;
        }
        else
        {
            auxPlayAnimation = playAnimationTime;
            GetComponent<Animator>().Play("Attack", 0);
        }

        if(auxTimeToAttack > 0f)
        {
            auxTimeToAttack -= Time.deltaTime;
        }
        else
        {
            ThrowRandomAttack();
            auxTimeToAttack = timeToAttack;
        }
    }

    private void ThrowRandomAttack()
    {
        var randIndex = Random.Range(0, attPoints.Length);
        var throwable = Instantiate(bullet, attPoints[randIndex].position, attPoints[randIndex].rotation);
        throwable.transform.localScale += new Vector3(1.5f, 1.5f, 1.5f);
        throwable.GetComponent<Rigidbody>().AddForce(attPoints[randIndex].forward * bulletSpeed, ForceMode.Impulse);
    }
}
