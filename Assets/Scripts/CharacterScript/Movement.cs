using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] float runningSpeed = 2f;
    [SerializeField] float rotationSpeed  = 5f;
    [SerializeField] TMPro.TextMeshProUGUI playerLifeText;
    private CharacterController charCont;
    private float x, xDir, y;
    private float playerLife = 100f;

    // Start is called before the first frame update
    void Start()
    {
        charCont = GetComponent<CharacterController>();
        playerLife = 100f;
        runningSpeed = 2f;
        playerLifeText.SetText("100%");
    }

    // Update is called once per frame
    void Update()
    {
        anim = GetComponent<Animator>();
        Move();
        if (Input.GetKeyDown(KeyCode.Q))
        {
            LoadScene();
        }
    }

    protected void Move()
    {
        var actRunSpeed = runningSpeed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            actRunSpeed = runningSpeed * 1.5f;
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
        playerLifeText.SetText("{0}%", playerLife);
        if (playerLife <= 0f)
        {
            SceneManager.LoadScene((int)Scenes.FIRSTLEVEL);
            // Game Over
        }
    }

    private void LoadScene()
    {
        // Como seria mejor manejar estas cuestiones? Digamos que quiero que reinicie la escena, pero si
        // tengo la llave, que aparezca como inactiva asi no la veo más y puedo pasar directo por la puerta.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        if (GameManager.instance.gotItuRustKey)
        {
            Debug.Log("Got the Key");

        }
        else
        {
            Debug.Log("Didn't got the key");
        }
        
    }
}
