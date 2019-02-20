using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void Controls()
    {
        SceneManager.LoadScene("Controls");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
