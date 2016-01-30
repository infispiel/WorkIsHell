using UnityEngine;
using System.Collections; 
using UnityEngine.UI;

public class Interactable : MonoBehaviour {
	public string message = "";
	public Sprite portrait;
	public GameObject dialogue;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public virtual Object doInteract(GameObject sender)
	{
		dialogue.GetComponent<DialogueMaster> ().showText (message, portrait);
		return new Object();
	}
}
