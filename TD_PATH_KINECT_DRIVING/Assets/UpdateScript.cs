using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScript : MonoBehaviour {

	private KinectButtonPress KinectButton; 
	public Image healthBar;

	[SerializeField]
	private GameObject TowerPrefab;

	// Use this for initialization
	void Start () {
		KinectButton = transform.GetComponentInParent<KinectButtonPress> ();

	}
	
	// Update is called once per frame
	void Update () {

		BuildingManager bm = GameObject.Find ("_Scripts_").GetComponent<BuildingManager>();


		if (TowerPrefab == null) {
			if (healthBar != null) {

				healthBar.fillAmount = KinectButton.CDtTime / KinectButton.CDcTime;
				Debug.Log (healthBar.fillAmount);
			}
		} else {
			
			if (bm != null) {
				if (bm.selectedTower == TowerPrefab) {
				
					if (healthBar != null) {

						healthBar.fillAmount = 1;
						Debug.Log (healthBar.fillAmount);
					}
				} else {
					if (healthBar != null) {

						healthBar.fillAmount = KinectButton.CDtTime / KinectButton.CDcTime;
						Debug.Log (healthBar.fillAmount);
					}
				}
			}
		}




	}
}
