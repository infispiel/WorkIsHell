﻿using UnityEngine;
using System.Collections; 
using UnityEngine.UI;

public class Interactable : MonoBehaviour {
	public string message = "";
	public GameObject dialogue;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void doInteract()
	{
		dialogue.GetComponent<DialogueMaster> ().showText (message);
	}
}
