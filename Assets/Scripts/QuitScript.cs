using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitScript : MonoBehaviour
{
    public void ExitApp()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        GameManager.instance.gotExitKey = GameManager.instance.gotItuRustKey = GameManager.instance.isPanelActive = false;
        SceneManager.LoadScene(0);
    }
}
