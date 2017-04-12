using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class KinectButtonPress : MonoBehaviour {
	// Stores the button along with its press.
	Button yourButton;
	float CDcTime = 0f;
	float CDtTime = 1f;

	void Start()
	{
		yourButton = this.GetComponent<Button> ();

		if (yourButton == null) {
			Debug.Log ("NoButton");
		} else
			Debug.Log (yourButton.name);

	}

	void OnTriggerEnter(Collider other)
	{

		if (other.name == "HandLayer") {
			//if(other.name == "HandLayer")
			CDtTime -= Time.deltaTime;

			if (CDtTime <= 0) {
				Debug.Log (other.name);
				yourButton.onClick.Invoke ();
			}
		}
	}



}
