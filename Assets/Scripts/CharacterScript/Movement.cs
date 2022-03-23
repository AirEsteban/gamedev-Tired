using System;
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
    [SerializeField] AudioClip pickUpSound;
    public static event Action OnDeath;
    private CharacterController charCont;
    private float x, xDir, y;
    private float playerLife = 100f;


    private void Awake()
    {
        SyringeColliderScript.OnDamage += TakeDmg;
    }
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
        Debug.Log("OnDamage event response invoked by the Movement Script");
        playerLife -= dmg;
        playerLifeText.SetText("{0}%", playerLife);
        if (playerLife <= 0f)
        {
            playerLifeText.SetText("{0}%", 0);
            Debug.Log("OnDeath event fired from the Movement Script");
            OnDeath?.Invoke();
            //SceneManager.LoadScene((int)Scenes.FIRSTLEVEL);
            // Game Over
        }
    }

    private void LoadScene()
    {
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

    public void PlayHangingScreamer()
    {
        Debug.Log("OnHangingRoomEnter UnityEvent response made by the Movement Script");
        var audioSrc = this.GetComponent<AudioSource>();
        if(null != audioSrc)
        {
            audioSrc.PlayOneShot(audioSrc.clip);
        }
    }

    public void PlayPickUpItemMusic()
    {
        Debug.Log("OnPickUpKey UnityEvent response made by the Movement Script");
        var audioSrc = this.GetComponent<AudioSource>();
        if(null != audioSrc)
        {
            audioSrc.PlayOneShot(pickUpSound);
        }
    }

    public void PlayPickUpKeyAnimation(Transform lookAtGameObject)
    {
        Debug.Log("OnPickUpScreamer UnityEvent response made by the Movement Script");
        this.transform.LookAt(lookAtGameObject, Vector3.up);
    }

}
