using UnityEngine;
using System.Collections;

public class Item : Interactable {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override Object doInteract()
	{
		dialogue.GetComponent<DialogueMaster> ().showText (message, portrait);
		Destroy (this.gameObject);
		return this;
	}
}
