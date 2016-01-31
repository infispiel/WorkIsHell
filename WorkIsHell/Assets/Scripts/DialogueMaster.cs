using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DialogueMaster : MonoBehaviour {
	public const int MAX_MSG = 100;
	public const int SHOW_TIME = 100;
    public player p;

	bool showing = false;
	public DialogueMessage[] messages = new DialogueMessage[MAX_MSG];
	public int message_count = 0;
    public int start = 0;
	int counter = SHOW_TIME;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(counter == -1)
        {
            return;
        }
		else if (counter > 0) {
			counter --;
		}
		else if (message_count - start > 0) {
            p.isDialogueMode = true;
			showing = true;
			show ();
            print("showing");
            print(messages[Mathf.FloorToInt((start) % MAX_MSG)].message);
            if(messages[Mathf.FloorToInt((start) % MAX_MSG)].isConvo == true)
            {
                DisplayText(messages[Mathf.FloorToInt((start) % MAX_MSG)]);
                start++;
                counter = -1;
            }
            else
            {
                print(start);
                DisplayText(messages[Mathf.FloorToInt((start) % MAX_MSG)]);
                start++;
                counter = SHOW_TIME;
            }
		} else if (showing == true) {
            this.GetComponent<AudioSource>().Stop();
			showing = false;
            p.isDialogueMode = false;
			hide ();
		}

	}

    public void chooseOption(int opt)
    {
        if(opt == 1)
        {
            this.DisplayText(new DialogueMessage(messages[Mathf.FloorToInt((start) % MAX_MSG)].response1,
                messages[Mathf.FloorToInt((start) % MAX_MSG)].picLoc));
        }
        else
        {

            this.DisplayText(new DialogueMessage(messages[Mathf.FloorToInt((start) % MAX_MSG)].response2,
                messages[Mathf.FloorToInt((start) % MAX_MSG)].picLoc));
        }
        this.GetComponent<Transform>().FindChild("Option 1").gameObject.SetActive(false);
        this.GetComponent<Transform>().FindChild("Option 2").gameObject.SetActive(false);
        this.GetComponent<Transform>().FindChild("Cursor 1").gameObject.SetActive(false);
        this.GetComponent<Transform>().FindChild("Cursor 2").gameObject.SetActive(false);
        start++;
        counter = SHOW_TIME;
        message_count --;
    }

	public void showText(string mesInp, Sprite picInp)
	{
		if (message_count - start < MAX_MSG) {
			messages[Mathf.FloorToInt(message_count % MAX_MSG)] = new DialogueMessage (mesInp, picInp, p.voice);
            message_count++;
        }
    }
    public void showText(DialogueMessage inp)
    {
        if (message_count - start < MAX_MSG)
        {
            messages[Mathf.FloorToInt(message_count % MAX_MSG)] = inp;
            message_count++;
        }
    }
    public void showText(string[] messages, bool[] isPlayer, Sprite picInp, AudioClip aud = null)
    {
        for(int i = 0; i < messages.Length; i ++)
        {
            if(isPlayer[i])
            {
                showText(new DialogueMessage(messages[i]));
            }
            else
            {

                showText(new DialogueMessage(messages[i], picInp, aud));
            }
        }
    }

    private void DisplayText(DialogueMessage inp)
    {
        if (inp.audio != null)
        {
            print("playing");
            if (this.GetComponent<AudioSource>().clip != inp.audio || !this.GetComponent<AudioSource>().isPlaying)
            {
                this.GetComponent<AudioSource>().clip = inp.audio;
                this.GetComponent<AudioSource>().Play();
            }
        }
        else if (inp.isPlayer)
        {
            print("playing");
            if (this.GetComponent<AudioSource>().clip != p.voice || !this.GetComponent<AudioSource>().isPlaying)
            {
                this.GetComponent<AudioSource>().clip = p.voice;
                this.GetComponent<AudioSource>().Play();
            }
        }
        else { print("did not play"); this.GetComponent<AudioSource>().Stop(); }
        if(inp.isPlayer)
        {
            ((Image)this.GetComponent<Transform>().FindChild("Portrait").GetComponent<Image>()).enabled = false;
        }
        else
        {

            ((Image)this.GetComponent<Transform>().FindChild("Portrait").GetComponent<Image>()).enabled = true;
        }
        if(inp.isConvo == false)
        {
            print("not a convo");
            this.GetComponentInChildren<Text>().text = inp.message;
            ((Image)this.GetComponent<Transform>().FindChild("Portrait").GetComponent<Image>()).sprite = inp.picLoc;
        }
        else
        {
            print("is a convo");
            p.isConvoMode = true;
            this.GetComponentInChildren<Text>().text = inp.message;
            ((Image)this.GetComponent<Transform>().FindChild("Portrait").GetComponent<Image>()).sprite = inp.picLoc;
            this.GetComponent<Transform>().FindChild("Option 1").gameObject.SetActive(true);
            this.GetComponent<Transform>().FindChild("Cursor 1").gameObject.SetActive(true);
            this.GetComponent<Transform>().FindChild("Option 2").gameObject.SetActive(true);
            p.setConvoMode(true, this.GetComponent<Transform>().FindChild("Cursor 1").gameObject, this.GetComponent<Transform>().FindChild("Cursor 2").gameObject);
        }
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
