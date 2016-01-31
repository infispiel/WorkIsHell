using UnityEngine;
using System.Collections;

public class DialogueMessage {
	public readonly string message;
	public readonly Sprite picLoc;
    public readonly bool isConvo;
    public readonly string option1;
    public readonly string response1;
    public readonly string option2;
    public readonly string response2;
    public readonly bool isPlayer;
    public readonly AudioClip audio = null;

    public DialogueMessage(string mesInp, Sprite picInp, AudioClip aud = null)
	{
		message = mesInp;
		picLoc = picInp;
        isConvo = false;
        isPlayer = false;
        audio = aud;
    }
    public DialogueMessage(string mesInp, AudioClip aud = null)
    {
        message = mesInp;
        isPlayer = true;
        isConvo = false;
        audio = aud;
    }

    public DialogueMessage(string mesInp, Sprite picInp, string op1inp, string re1inp, string op2inp, string re2inp, AudioClip aud = null)
    {
        message = mesInp;
        picLoc = picInp;
        option1 = op1inp;
        option2 = op2inp;
        response1 = re1inp;
        response2 = re2inp;
        isConvo = true;
    }
}
