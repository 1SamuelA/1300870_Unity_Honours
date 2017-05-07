using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScript : MonoBehaviour {

	private KinectButtonPress KinectButton; 
	public Image healthBar;

	// Use this for initialization
	void Start () {
		KinectButton = transform.GetComponentInParent<KinectButtonPress> ();

	}
	
	// Update is called once per frame
	void Update () {

		if(healthBar != null)
		{

			healthBar.fillAmount = KinectButton.CDtTime / KinectButton.CDcTime;
			Debug.Log (healthBar.fillAmount);
		}

	}
}
