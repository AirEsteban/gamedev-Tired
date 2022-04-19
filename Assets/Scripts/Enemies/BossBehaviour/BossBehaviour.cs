using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : FollowWpAndAttack
{
    [SerializeField] bool towardsPlayer = false;
    [SerializeField] GameObject instEnemy;
    [SerializeField] List<GameObject> invokePoints = new List<GameObject>();
    [SerializeField] GameObject sprayAttack;

    private bool canAttackChar = false;
    private bool isEnemyInvoked = false;
    private int countInvoke = 0;
    private int countAttack = 0;
    private int enemiesAlive = 0;
    private bool isAlive = true;
    void Update()
    {
        if (isAlive)
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
    }

    public void FollowPlayerAndAttack()
    {
        base.anim.SetBool("walk", false);
        this.transform.LookAt(attackedObj);
        var attackedObjPos = attackedObj.position - gameObject.transform.position;
        base.anim.SetTrigger("walkTowards");
        if(Mathf.Abs(attackedObjPos.magnitude) >= 3f)
        {
            this.transform.Translate(attackedObjPos.normalized * Time.deltaTime * (base.enemyData.charSpeed + 0.8f)
           , Space.World);
        }
        else
        {
            if (canAttackChar)
            {
                base.anim.ResetTrigger("walkTowards");
                base.anim.SetTrigger("attack");
                canAttackChar = false;
                sprayAttack.GetComponent<ParticleSystem>().Play();
            }
        }

        if (!isEnemyInvoked)
        {
            InvokeEnemy();
        }

        countAttack++;
        countInvoke++;
        if (countInvoke == 1000)
        {
            if(enemiesAlive < 3)
            {
                isEnemyInvoked = false;
                anim.ResetTrigger("Invoke");
            }
            countInvoke = 0;
        }

        if(countAttack == 350)
        {
            canAttackChar = true;
            countAttack = 0;
        }
    }

    private void InvokeEnemy()
    {
        if (null != instEnemy)
        {
            isEnemyInvoked = true;
            anim.SetTrigger("Invoke");
            var invokeIndex = UnityEngine.Random.Range(0, invokePoints.Count);
            var enemy = Instantiate(instEnemy, invokePoints[invokeIndex].transform, false);
            enemy.transform.LookAt(attackedObj);
            enemy.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            enemiesAlive++;
        }
    }

    public void DecrementAliveEnemies()
    {
        this.enemiesAlive--;
    }

    public void ChangeTowardsPlayer()
    {
        this.towardsPlayer = true;
    }

    public override void TakeDmg(float dmg)
    {
        Debug.Log("Entre al correctto");
        enemyData.enemyLife -= dmg;
        if (enemyData.enemyLife <= 0)
        {
            GameManager.instance.gotExitKey = true;
            Destroy(this.gameObject);
        }
    }
}