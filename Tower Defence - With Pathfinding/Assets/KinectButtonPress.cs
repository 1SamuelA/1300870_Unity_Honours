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
	float CDtTime = 3f;

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
		Debug.Log("Enter");
		CDcTime = CDtTime;
	}

	void OnTriggerStay(Collider other)
	{
		CDcTime -= Time.deltaTime;
		if (CDcTime <= CDtTime) 
		{
			Debug.Log("Mesh Hovering");
			yourButton.onClick.Invoke ();

			//UnityEngine.EventSystems.ExecuteEvents.Execute<> (yourButton.gameObject, new PointerEventData (EventSystem.current), EvecuteEvents.pointerClickHandler);
			//yourButton.ButtonClickedEvent.Invoke;

		}
	}

}
