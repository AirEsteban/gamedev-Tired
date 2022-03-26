using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] float runningSpeed = 2f;
    [SerializeField] float rotationSpeed  = 5f;
    [SerializeField] TMPro.TextMeshProUGUI playerLifeText;
    [SerializeField] AudioClip pickUpSound;
    [SerializeField] AudioClip[] hurtAudio = new AudioClip[3];
    public static event Action OnDeath;
    [SerializeField] public UnityEvent OnTakeDmg;
    private CharacterController charCont;
    private float x, xDir, y;
    private float playerLife = 100f;
    private AudioSource audioSrc;


    private void Awake()
    {
        SyringeColliderScript.OnDamage += TakeDmg;
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
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
        if(null != audioSrc)
        {
            audioSrc.volume = 0.3f;
            var ind = UnityEngine.Random.Range(0, hurtAudio.Length);
            audioSrc.PlayOneShot(hurtAudio[ind]);
        }
        audioSrc.volume = 1f;
        playerLifeText.SetText("{0}%", playerLife);
        OnTakeDmg?.Invoke();
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
