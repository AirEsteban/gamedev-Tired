using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] float rotationSpeed = 200f;
    [SerializeField] float runningSpeed = 2f;
    private float x, y;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        anim = GetComponent<Animator>();
        Move();
        /*if (Input.GetKey(KeyCode.W))
        {
            Move(Vector3.forward);
            CurarJugador();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Move(Vector3.back);
            CurarJugador();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Move(Vector3.left);
            PegarleAJugador();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Move(Vector3.right);
            PegarleAJugador();
        }*/
    }

    protected void Move()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        var indepSpeed = Time.deltaTime * runningSpeed;
        transform.Translate(x * indepSpeed, 0, y * indepSpeed);

        anim.SetFloat("getX", x);
        anim.SetFloat("getY", y);
    }

}
