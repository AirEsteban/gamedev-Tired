using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] float runningSpeed = 2f;
    [SerializeField] float rotationSpeed  = 5f;
    private CharacterController charCont;
    private float x, xDir, y;
    private float playerLife = 100f;

    // Start is called before the first frame update
    void Start()
    {
        charCont = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        anim = GetComponent<Animator>();
        Move();
    }

    protected void Move()
    {
        var actRunSpeed = runningSpeed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            actRunSpeed = runningSpeed * 2f;
        }

        // Character Controller
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        var indepSpeed = Time.deltaTime * actRunSpeed;
        
        charCont.Move(transform.TransformDirection(x * indepSpeed, 0f, y * indepSpeed));

        //RotateCharacter
        RotateCharacter();

        // Animation Playing
        SetAnimatorParams();
    }

    protected void RotateCharacter()
    {
       xDir += Input.GetAxis("Mouse X");
       transform.localRotation = Quaternion.Euler(0, xDir * rotationSpeed ,0f);
    }


    protected void SetAnimatorParams()
    {
        // Animator Params
        anim.SetFloat("getX", x);
        anim.SetFloat("getY", y);
    }

    public void TakeDmg(float dmg)
    {
        playerLife -= dmg;

        if(playerLife <= 0f)
        {
            Debug.Log("Player Life: " + playerLife);
            // Game Over
        }
    }

}
