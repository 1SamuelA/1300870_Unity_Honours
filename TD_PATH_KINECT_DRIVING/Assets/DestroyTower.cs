using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTower : MonoBehaviour {

	[SerializeField]
	private GameObject TowerSpot;
	public float CDcTime = 1f;
	public float CDtTime = 0f;
	public float WaitTime = 1f;

	// Use this for initialization
	void Start () {
		
	}

	void OnMouseUp()
	{
		ScoreManager sm = GameObject.FindObjectOfType<ScoreManager>();
		sm.money -= GetComponentInParent<Tower> ().cost /2;
		Instantiate(TowerSpot, transform.parent.position, transform.parent.rotation);
		Destroy(transform.parent.gameObject);
	}

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

	// Update is called once per frame
	void Update()
	{

		WaitTime -= Time.deltaTime;
		if (WaitTime <= 0) {
			CDtTime = 0;
			Debug.Log ("Timer Stopped");
		}
	}
}
