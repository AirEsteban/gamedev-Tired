using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ThrowSimpleAttack();
    }

    private void ThrowSimpleAttack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("simpleAttack", true);
        }
    }
}
