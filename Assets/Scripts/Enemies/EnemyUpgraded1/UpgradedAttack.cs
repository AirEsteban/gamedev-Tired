using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UpgradedAttack : MonoBehaviour
{
    [SerializeField] ScriptableUpgEnemy upgEnemyData;
    [SerializeField] public Transform[] attPoints = new Transform[6];
    [SerializeField] public UnityEvent OnDestroy; 
    private float playAnimationTime = 5f;
    private float auxPlayAnimation;
    private float auxTimeToAttack;

    private void Start()
    {
        auxTimeToAttack = upgEnemyData.timeToAttack;
        auxPlayAnimation = playAnimationTime;
        upgEnemyData.enemyLife = 200f;
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
            auxTimeToAttack = upgEnemyData.timeToAttack;
        }
    }

    private void ThrowRandomAttack()
    {
        var randIndex = Random.Range(0, attPoints.Length);
        var throwable = Instantiate(upgEnemyData.bullet, attPoints[randIndex].position, attPoints[randIndex].rotation);
        throwable.transform.localScale += new Vector3(1.5f, 1.5f, 1.5f);
        throwable.GetComponent<Rigidbody>().AddForce(attPoints[randIndex].forward * upgEnemyData.bulletSpeed, ForceMode.Impulse);
    }

    public void TakeDmg(float dmg)
    {
        upgEnemyData.enemyLife -= dmg;
        if (upgEnemyData.enemyLife <= 0)
        {
            Destroy(this.gameObject);
            OnDestroy.Invoke();
        }
    }
}
