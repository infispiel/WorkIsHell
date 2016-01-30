using UnityEngine;
using System.Collections;

public class Item : Interactable {
    public int id;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override Object doInteract(GameObject sender)
	{
		dialogue.GetComponent<DialogueMaster> ().showText (message, portrait);
		Destroy (this.gameObject);
		return this;
	}
}
