using UnityEngine;
using System.Collections;

public class CameraCrap : MonoBehaviour {
    public float nsmanip = -0.2f;
    public float ewmanip = 0f;
    Vector3 TopPos = new Vector3(0, 2, -10);
    Vector3 BottomPos = new Vector3(0, 0, -10);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Transform t = other.gameObject.GetComponent<Transform>().FindChild("Main Camera").GetComponent<Transform>();
        StartCoroutine(LerpToPosition(0.5f, TopPos, other, true));
    }
    void OnTriggerExit2d(Collider2D other)
    {
        Transform t = other.gameObject.GetComponent<Transform>().FindChild("Main Camera").GetComponent<Transform>();
        StartCoroutine(LerpToPosition(0.5f, BottomPos, other, true));
    }


    IEnumerator LerpToPosition(float lerpSpeed, Vector3 newPosition, Collider2D other, bool useRelativeSpeed = false)
    {
        if (useRelativeSpeed)
        {
            float totalDistance = BottomPos.y - TopPos.y;
            float diff = other.gameObject.GetComponent<Transform>().FindChild("Main Camera").GetComponent<Transform>().position.x - TopPos.y;
            float multiplier = diff / totalDistance;
            lerpSpeed *= multiplier;
        }

        float t = 0.0f;
        Vector3 startingPos = other.gameObject.GetComponent<Transform>().FindChild("Main Camera").GetComponent<Transform>().position;
        while (t < 1.0f)
        {
            t += Time.deltaTime * (Time.timeScale / lerpSpeed);

            other.gameObject.GetComponent<Transform>().FindChild("Main Camera").GetComponent<Transform>().position = Vector3.Lerp(startingPos, newPosition, t);
            yield return 0;
        }
    }
}
