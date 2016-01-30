using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DialogueMaster : MonoBehaviour {
	public const int MAX_MSG = 100;
	public const int SHOW_TIME = 100;

	bool showing = false;
	DialogueMessage[] messages = new DialogueMessage[MAX_MSG];
	int message_count = 0;
	int start = 0;
	int counter = SHOW_TIME;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (counter > 0) {
			counter --;
		}
		else if (message_count > 0) {
			showing = true;
			show ();
			ShowText (messages [Mathf.FloorToInt((message_count+start)/MAX_MSG)]);
            start++;
            counter = SHOW_TIME;
			message_count --;
		} else if (showing == true) {
			showing = false;
			hide ();
		}

	}

	public void showText(string mesInp, Sprite picInp)
	{
		if (message_count < MAX_MSG) {
			message_count ++;
			messages[message_count-1] = new DialogueMessage (mesInp, picInp);
		}
	}

	private void ShowText(DialogueMessage inp)
	{
		this.GetComponentInChildren<Text> ().text = inp.message;
		((Image)this.GetComponent<Transform> ().FindChild ("Portrait").GetComponent<Image> ()).sprite = inp.picLoc;
	}

	private void hide()
	{
		this.transform.localScale = new Vector3 (0, 0, 0);
	}

	private void show()
	{
		this.transform.localScale = new Vector3 (1, 1, 1);
	}
}
