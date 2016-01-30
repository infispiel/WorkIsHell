using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class pauseMenu : MonoBehaviour {

    public GameObject PauseUI;
    public GameObject player;
    public GameObject item1;
    public GameObject item2;
    public GameObject item3;

    private bool paused = false;

    void Start() {

        PauseUI.SetActive(false);
        
    }

    void Update(){

        if (Input.GetButtonDown("Pause"))
        {
            paused = !paused;
        }
        if (paused)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }
        if (!paused)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1;
        }

        if (player.Inventory.Contains(item1))
        {
            item1.SetActive(true);
        }

    }



    public void Resume()
    {
        paused = false;
    }
}
