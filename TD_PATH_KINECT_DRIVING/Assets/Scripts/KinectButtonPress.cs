using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

/// <summary>
/// 
/// </summary>
public class KinectButtonPress : MonoBehaviour {
	// Stores the button along with its press.
	Button yourButton;
	public float CDcTime = 1f;
	public float CDtTime = 0f;
	public float WaitTime = 1f;

    /// <summary>
    /// Starts this instance.
    /// </summary>
    void Start()
	{
		yourButton = this.GetComponent<Button> ();

		if (yourButton == null) {
			Debug.Log ("NoButton");
		} else
			Debug.Log (yourButton.name);

	}


	void Update()
	{

		WaitTime -= Time.deltaTime;
		if (WaitTime <= 0) {
			CDtTime = 0;
			Debug.Log ("Timer Stopped");
		}
	}
    /// <summary>
    /// Called when [trigger enter].
    /// </summary>
    /// <param name="other">The other.</param>
    void OnTriggerEnter(Collider other)
	{

		if (other.name == "HandLayer") {
			//if(other.name == "HandLayer")
			CDtTime += Time.deltaTime;

			WaitTime = 1;

			if (CDtTime >= 1) {
				CDtTime = 1;
				Debug.Log (other.name);
				yourButton.onClick.Invoke ();
			}
		}
	}

	void OnTriggerExit(Collider other)
	{


	}

}
