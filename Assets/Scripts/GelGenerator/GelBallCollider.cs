using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GelBallCollider : MonoBehaviour
{
    [SerializeField] float dmg = 25f;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Movement>().TakeDmg(dmg);
        }
        Destroy(this.gameObject);
    }

}
