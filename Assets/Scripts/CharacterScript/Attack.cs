using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public enum EnumAttackType { Simple = 0 }
public class Attack : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] GameObject SimpleAttackObj;
    [SerializeField] Rigidbody rbSimpleAttackObj;
    [SerializeField] Transform attackPoint;

    // auxiliar
    [SerializeField] float timeToAttack = 0.72f;
    [SerializeField] float auxTimetoAttack;

    [SerializeField] float bulletSpeed = 3f;
    [SerializeField] bool canAttack;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        canAttack = true;
        auxTimetoAttack = timeToAttack;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canAttack)
        {
            ThrowAttack(this.anim);
            canAttack = false;
        }
        else
        {
            if (!canAttack && auxTimetoAttack > 0f)
            {
                auxTimetoAttack -= Time.deltaTime;
            }
            else
            {
                auxTimetoAttack = timeToAttack;
                canAttack = true;
            }
        }
    }

    private void ThrowAttack(Animator anim)
    {
        anim.SetTrigger("attackTrigger");
        var bullet = Instantiate(SimpleAttackObj, attackPoint.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().AddForce(attackPoint.forward * bulletSpeed, ForceMode.Impulse);
    }
}
