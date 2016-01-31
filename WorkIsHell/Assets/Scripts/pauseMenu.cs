using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class pauseMenu : MonoBehaviour {

    public GameObject PauseUI;
    public player player;
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
            this.GetComponent<AudioLowPassFilter>().enabled = false;
            paused = !paused;
        }
        if (paused)
        {
            this.GetComponent<AudioLowPassFilter>().enabled = true;
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }
        if (!paused)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1;
        }

        if (player.Inventory.Count > 0)
        {
            item1.GetComponent<SpriteRenderer>().sprite = player.Inventory[0].portrait;

            if (player.Inventory.Count > 1)
            {
                item2.GetComponent<SpriteRenderer>().sprite = player.Inventory[1].portrait;
                if (player.Inventory.Count > 2)
                {
                    item3.GetComponent<SpriteRenderer>().sprite = player.Inventory[2].portrait;

                }
            }

        }

    }



    public void Resume()
    {
        this.GetComponent<AudioLowPassFilter>().enabled = false;
        paused = false;
    }
}
