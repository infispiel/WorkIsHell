using UnityEngine;
using System.Collections;

public class Questor : Interactable {
    public int state = 0;
    public int desiredItemID;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override Object doInteract(GameObject sender)
    {
        if(sender.GetComponent<player>().hasItem(desiredItemID) )
        {
            dialogue.GetComponent<DialogueMaster>().showText("hey cool you got it...", portrait);
            sender.GetComponent<player>().removeItem(desiredItemID);
            state = 1;
        } 
        else if (state == 0)
        {
            dialogue.GetComponent<DialogueMaster>().showText("hey could you get me an item", portrait);
        }
        else
        {
            dialogue.GetComponent<DialogueMaster>().showText("hey.... thanks again", portrait);
        }
        return this;
    }
}
