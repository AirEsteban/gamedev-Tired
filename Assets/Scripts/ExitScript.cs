using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(GameManager.instance.gotExitKey);
        if (other.gameObject.CompareTag("Player") && GameManager.instance.gotExitKey)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            Debug.Log("An error has ocurred.");
        }
    }
}
