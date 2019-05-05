using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class WinAndPause : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = true; 
    }

    public void Resume()
    {
        Destroy(GameObject.Find("Scene"));
        Cursor.visible = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
        Cursor.visible = false;
    }

    public void Menu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
