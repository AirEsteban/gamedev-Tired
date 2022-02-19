using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnumAttackType { Simple = 0 }
public class Attack : MonoBehaviour
{
    [SerializeField] Animator anim;
    private EnumAttackType attackType;
    [SerializeField] GameObject[] attackBullets;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        attackType = EnumAttackType.Simple;
    }

    // Update is called once per frame
    void Update()
    {
        ThrowAttack();
    }

    private void ThrowAttack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            attackType = EnumAttackType.Simple;
            Invoke("AttackType", 0.7f);
            anim.SetBool("simpleAttack", true);
        }
    }

    private void AttackType()
    {
        switch (attackType)
        {
            case EnumAttackType.Simple:
                Instantiate(attackBullets[(int)EnumAttackType.Simple]);
                break;
            default:
                Debug.Log("No attack found.");
                break;
        }

    }
}
