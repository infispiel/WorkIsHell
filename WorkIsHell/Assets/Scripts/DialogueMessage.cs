using UnityEngine;
using System.Collections;

public class DialogueMessage {
	public readonly string message;
	public readonly Sprite picLoc;

	public DialogueMessage(string mesInp, Sprite picInp)
	{
		message = mesInp;
		picLoc = picInp;
	}
}
