using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class player : MonoBehaviour {
	List<Collider2D> TriggerList = new List<Collider2D>();
	public List<Item> Inventory = new List<Item> ();
    public DialogueMaster dialogue;
    public bool selectOne = true;
    public bool isDialogueMode = false;
    public AudioClip voice;

    GameObject cursor1;
    GameObject cursor2;
    public bool isConvoMode = false;

    public float moveSpeed = 2;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        Object Res;
        List<Moveable> toRemove = new List<Moveable>();
        if(isConvoMode || isDialogueMode)
        {
            this.GetComponent<Transform>().FindChild("Main Camera").GetComponent<AudioSource>().volume = 0.5f;
        }
        else
        {
            this.GetComponent<Transform>().FindChild("Main Camera").GetComponent<AudioSource>().volume = 1f;
        }
        if (!isConvoMode && !isDialogueMode)
        {
            if (Input.GetKeyUp("space"))
            {
                print("space pressed");
                foreach (Collider2D a in TriggerList)
                {
                    Res = a.GetComponent<Interactable>().doInteract(this.gameObject);
                    if (Res is Item && !Inventory.Contains((Item)Res))
                    {
                        Inventory.Add((Item)Res);
                        print("Count: " + Inventory.Count);
                    }
                    if (Res is Moveable)
                    {
                        if (!this.GetComponent<BoxCollider2D>().bounds.Contains(((Moveable)Res).GetComponent<Transform>().position))
                        {
                            toRemove.Add((Moveable)Res);
                        }
                    }
                    break;
                }

                foreach (Moveable obj in toRemove)
                {
                    TriggerList.Remove((obj).GetComponent<BoxCollider2D>());
                }
                toRemove.Clear();
            }
        }
        }
	public void setConvoMode(bool modeset, GameObject cursor1inp, GameObject cursor2inp)
    {
        isConvoMode = true;
        cursor1 = cursor1inp;
        cursor2 = cursor2inp;
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
	{if (!isConvoMode && !isDialogueMode)
        {
            // Cache the inputs.
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            move(h, v);
            TriggerList.RemoveAll(item => item == null);

        }
        else if(isConvoMode)
        {
            if (Input.GetKeyDown("up") || Input.GetKeyDown("down"))
            {
                selectOne = !selectOne;
                cursor1.SetActive(selectOne);
                cursor2.SetActive(!selectOne);
            }
            else if (Input.GetKeyUp("space"))
            {
                if(selectOne)
                {
                    dialogue.chooseOption(1);
                }
                else
                {
                    dialogue.chooseOption(2);
                }
                isConvoMode = false;
            }
        }
	}

	void move (float horizontal, float vertical)
	{
		// If there is some axis input...
		if (horizontal != 0f || vertical != 0f)
        {
            GetComponent<Animator>().speed = 1;
            this.GetComponent<AudioSource>().enabled = true;
            if(Mathf.Abs(horizontal) > Mathf.Abs(vertical))
            {
                if(horizontal > 0)
                {
                    GetComponent<Animator>().Play("player_walk",0);
                }
                else
                {
                    GetComponent<Animator>().Play("player_walkL", 0);
                }
            }
            else
            {
                if(vertical > 0)
                {
                    GetComponent<Animator>().Play("player_walkN", 0);
                }
                else
                {
                    GetComponent<Animator>().Play("player_walkS", 0);
                }
            }
            GetComponent<Rigidbody2D>().velocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);
		} else
        {
            GetComponent<Animator>().speed = 0;
            this.GetComponent<AudioSource>().enabled = false;
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
