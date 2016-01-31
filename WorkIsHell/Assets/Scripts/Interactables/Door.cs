using UnityEngine;
using System.Collections;

public class Door : Interactable {
    public GameObject FogOfWar;
    public bool isOpen = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override Object doInteract(GameObject sender)
    {
        //this.animate opening
        if(isOpen)
        {
            FogOfWar.GetComponent<SpriteRenderer>().enabled = false;
            this.isOpen = true;
        }
        else
        {
            FogOfWar.GetComponent<SpriteRenderer>().enabled = true;
            this.isOpen = false;
        }
        return this;
    }
}
