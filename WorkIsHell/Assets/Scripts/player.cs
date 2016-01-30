using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class player : MonoBehaviour {
	List<Collider2D> TriggerList = new List<Collider2D>();
	public List<Item> Inventory = new List<Item> ();

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
		Object Res;
        List<Moveable> toRemove = new List<Moveable>();
		if (Input.GetKeyDown ("space")) {
			foreach (Collider2D a in TriggerList)
			{
				Res = a.GetComponent<Interactable>().doInteract(this.gameObject);
				if(Res is Item)
				{
					Inventory.Add((Item)Res);
					print (Inventory);
				}
                if(Res is Moveable)
                {
                    if (!this.GetComponent<BoxCollider2D>().bounds.Contains(((Moveable)Res).GetComponent<Transform>().position))
                    {
                        toRemove.Add((Moveable)Res);
                    }
                }
			}

            foreach(Moveable obj in toRemove)
            {
                TriggerList.Remove((obj).GetComponent<BoxCollider2D>());
            }
            toRemove.Clear();
		}

		// Cache the inputs.
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		
		move(h, v);
		TriggerList.RemoveAll(item => item == null);
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

    public bool hasItem(int itemID)
    {
        foreach(Item i in Inventory)
        {
            if (i.id == itemID) return true;
        }
        return false;
    }

    public void removeItem(int itemID)
    {
        foreach(Item i in Inventory)
        {
            if(i.id == itemID)
            {
                Inventory.Remove(i);
                break;
            }
        }
    }

}
