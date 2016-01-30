using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogueMaster : MonoBehaviour {
	bool showing = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void showText(string inp)
	{
		if (!showing) {
			showing = true;
			StartCoroutine (ShowText (inp));
		}
	}

	private IEnumerator ShowText(string inp)
	{
		show ();
		this.GetComponentInChildren<Text> ().text = inp;
		yield return new WaitForSeconds (5);
		hide ();
		showing = false;
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
