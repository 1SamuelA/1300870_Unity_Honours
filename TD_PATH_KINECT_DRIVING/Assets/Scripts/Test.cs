using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 a = this.gameObject.transform.position;

		a = a + new Vector3 (0, Time.deltaTime, 0);

		this.gameObject.transform.position = a;

	}
}
