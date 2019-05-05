using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Temp_GameManager : MonoBehaviour
{
    public Slider blood;
    public Slider carLife;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        blood.value = player.GetComponent<PlayerController>().bloodLeft;
        carLife.value = player.GetComponent<PlayerController>().lives;

        if (Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene(2, LoadSceneMode.Additive);
        }
    }
}
