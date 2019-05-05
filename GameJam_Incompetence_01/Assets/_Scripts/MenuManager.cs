using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public Image howToPlay;

    void Start()
    {
        howToPlay.enabled = false;
        Cursor.visible = true;
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            howToPlay.enabled = false;
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
        Cursor.visible = false;
    }

    public void HowToPlay()
    {
        howToPlay.enabled = true;
    }

    public void Quit()
    {
        //Application.Quit();
    }
}
