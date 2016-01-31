using UnityEngine;
using System.Collections; 
using UnityEngine.UI;

public class Interactable : MonoBehaviour {
	public string message = "";
    public bool isConversationalist = false;
    public string opt1 = "";
    public string res1 = "";
    public string opt2 = "";
    public string res2 = "";
    public bool isMultiline = false;
    public string[] multilines;
    public bool[] isPlayer;
    public AudioClip speakingAudio;

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
        if (isConversationalist)
        {
            dialogue.GetComponent<DialogueMaster>().showText(new DialogueMessage(message, portrait, opt1, res1, opt2, res2, speakingAudio));
        }
        else if (isMultiline)
        {
            dialogue.GetComponent<DialogueMaster>().showText(multilines, isPlayer, portrait, speakingAudio);
        }
        else
        {
            dialogue.GetComponent<DialogueMaster>().showText(new DialogueMessage(message, portrait, speakingAudio));
        }
		return new Object();
	}
}
