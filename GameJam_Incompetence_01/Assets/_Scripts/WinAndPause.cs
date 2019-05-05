using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class WinAndPause : MonoBehaviour
{
    public void Resume()
    {
        Destroy(GameObject.Find("Scene"));
    }

    public void Restart()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);

    }

    public void Menu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
