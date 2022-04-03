using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpitAttackCollider : MonoBehaviour
{
    [SerializeField] float dmg = 30f;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<FollowWpAndAttack>().TakeDmg(dmg);
        }

        if (collision.gameObject.CompareTag("EnemyUpg"))
        {
            collision.gameObject.GetComponent<UpgradedAttack>().TakeDmg(dmg);
        }
        Destroy(this.gameObject);
    }
}
