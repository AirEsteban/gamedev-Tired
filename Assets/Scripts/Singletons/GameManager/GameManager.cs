using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool gotItuRustKey = false;
    public bool gotExitKey = false;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            if (gotItuRustKey)
            {
                var ituRustKey = GameObject.Find("ituRustKey");
                if (null != ituRustKey)
                {
                    Debug.Log("entre al manager");
                    ituRustKey.SetActive(false);
                }
            }
        }
        else
        {
            Destroy(this);
        }
    }
}
