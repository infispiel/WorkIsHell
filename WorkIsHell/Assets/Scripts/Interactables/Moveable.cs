using UnityEngine;
using System.Collections;

public class Moveable : Interactable {
    public float MOVE_AMT = 0.2f;
    public LayerMask layer;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override Object doInteract(GameObject sender)
    {
        float dirX = 0f;
        float dirY = 0f; ;
        Vector2 direction = this.transform.position - sender.transform.position;
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                dirX = MOVE_AMT;
            }
            else if (direction.x < 0)
            {
                dirX = -MOVE_AMT;
            }
        }
        else
        {

            if (direction.y > 0)
            {
                dirY = MOVE_AMT;
            }
            else if (direction.y < 0)
            {
                dirY = -MOVE_AMT;
            }
        }
        //Store start position to move from, based on objects current transform position.
        Vector2 start = transform.position;

        // Calculate end position based on the direction parameters passed in when calling Move.
        Vector2 end = start + new Vector2(dirX, dirY);

        //Disable the boxCollider so that linecast doesn't hit this object's own collider.
        this.GetComponent<BoxCollider2D>().enabled = false;

        //Cast a line from start point to end point checking collision on blockingLayer.
        RaycastHit2D hit = Physics2D.Linecast(start, end, layer);

        //Re-enable boxCollider after linecast
        this.GetComponent<BoxCollider2D>().enabled = true;

        //Check if anything was hit
        if (hit.transform == null)
        {
            //If nothing was hit, start SmoothMovement co-routine passing in the Vector2 end as destination
            this.transform.position = end;
        }
        return this;
    }
}
