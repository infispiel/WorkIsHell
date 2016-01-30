using UnityEngine;
using System.Collections;

public class loadScene : MonoBehaviour {

	public void LoadScene(int level)
    {
        Application.LoadLevel(level);
    }
}
