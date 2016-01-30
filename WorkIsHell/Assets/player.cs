using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class player : MonoBehaviour {
	List<Collider2D> TriggerList = new List<Collider2D>();

	public float moveSpeed = 2;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		//if the object is not already in the list
		if(!TriggerList.Contains(other))
		{
			//add the object to the list
			TriggerList.Add(other);
		}
	}
	
	//called when something exits the trigger
	void OnTriggerExit2D( Collider2D other)
	{
		//if the object is in the list
		if(TriggerList.Contains(other))
		{
			//remove it from the list
			TriggerList.Remove(other);
		}
	}
	
	void FixedUpdate ()
	{
		if (Input.GetKeyDown ("space")) {
			print("space key was pressed");
			print (TriggerList.Count);
			foreach (Collider2D a in TriggerList)
			{
				print("a");
			}
		}

		// Cache the inputs.
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		
		move(h, v);
	}

	void move (float horizontal, float vertical)
	{
		// If there is some axis input...
		if (horizontal != 0f || vertical != 0f) {
			GetComponent<Rigidbody2D>().velocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);
		} else {
		}
			// Otherwise set the speed parameter to 0.
	}

}
