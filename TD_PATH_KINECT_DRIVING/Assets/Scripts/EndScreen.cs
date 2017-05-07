using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI()
	{

		ScoreManager SM = GameObject.FindObjectOfType<ScoreManager> ();
		if (SM == null) {
			return;
		}
		GUI.BeginGroup (new Rect (0, 0, Screen.width, Screen.height));
		GUI.TextField (new Rect (Screen.width - 600, 10, 250, 20), "Game Over");

		GUI.TextField (new Rect (Screen.width - 600, 10, 250, 40), "You had " +SM.lives+ " Lives Remaining");

		GUI.EndGroup ();
	}
}
