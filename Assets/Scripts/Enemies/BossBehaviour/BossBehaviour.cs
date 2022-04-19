using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : FollowWpAndAttack
{
    [SerializeField] bool towardsPlayer = false;
    [SerializeField] GameObject instEnemy;

    private bool canAttackChar = true;
    private bool canWalkTowards = true;

    void Update()
    {
        if (!towardsPlayer)
        {
            base.FollowWp();
        }
        else
        {
            FollowPlayerAndAttack();
        }
       
    }

    public void FollowPlayerAndAttack()
    {
        base.anim.SetBool("walk", false);
        this.transform.LookAt(attackedObj);
        var attackedObjPos = attackedObj.position - gameObject.transform.position;
        if (canWalkTowards)
        {
            base.anim.SetTrigger("walkTowards");
            canWalkTowards = false;
            canAttackChar = true;
        }

        if (Mathf.Abs(attackedObjPos.magnitude) <= 5f)
        {
            if (canAttackChar)
            {
                base.anim.SetTrigger("attack");
                base.anim.ResetTrigger("walkTowards");
                canAttackChar = false;
                canWalkTowards = true;
            }
        }

        if (Mathf.Abs(attackedObjPos.magnitude) <= 10f)
        {
            InvokeEnemy();
        }
    }

    private IEnumerable InvokeEnemy()
    {
        if (null != instEnemy)
        {
            Debug.Log("enemigo lleno");
            base.anim.SetTrigger("Invoke");
            base.anim.ResetTrigger("walkTowards");
            var enemy = Instantiate(instEnemy, this.attackPoint.transform, false);
            enemy.transform.LookAt(base.attackedObj);
            canWalkTowards = true;
            yield return new WaitForSeconds(5f);
        }
        else
        {
            Debug.Log("enemigo vacio");
        }
        yield return new WaitForSeconds(0f);
    }

    public void ChangeTowardsPlayer()
    {
        this.towardsPlayer = true;
    }
}