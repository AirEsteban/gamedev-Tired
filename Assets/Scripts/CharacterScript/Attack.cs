using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public enum EnumAttackType { Simple = 0 }
public class Attack : MonoBehaviour
{
    [SerializeField] Animator anim;
    //private EnumAttackType attackType;
    //[SerializeField] GameObject[] attackBullets;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        //attackType = EnumAttackType.Simple;
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
        //attackType = EnumAttackType.Simple;
        anim.SetTrigger("attackTrigger");
        //anim.ResetTrigger("attackTrigger");
    }

    private void AttackType()
    {
       /* switch (attackType)
        {
            case EnumAttackType.Simple:
                Instantiate(attackBullets[(int)EnumAttackType.Simple]);
                break;
            default:
                Debug.Log("No attack found.");
                break;
        }
       */
    }
}
