using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public enum EnumAttackType { Simple = 0 }
public class Attack : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] GameObject SimpleAttackObj;
    //private EnumAttackType attackType;
    //[SerializeField] GameObject[] attackBullets;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ThrowAttack();
        }
    }

    private void ThrowAttack()
    {
        anim.SetTrigger("attackTrigger");
        Instantiate(SimpleAttackObj);
    }
}
