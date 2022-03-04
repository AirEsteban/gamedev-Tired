using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyringeColliderScript : MonoBehaviour
{
    [SerializeField] float damage = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision objCollision)
    {
        // AttackDmg
        if (objCollision.gameObject.CompareTag("Player"))
        {
            objCollision.gameObject.GetComponent<Movement>().TakeDmg(damage);
        }

        // Destroying object on collision;
        Destroy(this.gameObject);
    }
}
