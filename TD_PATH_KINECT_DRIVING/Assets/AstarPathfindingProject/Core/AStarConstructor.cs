using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStarConstructor : MonoBehaviour {



	// Use this for initialization
	void Start () {
        this.GetComponent<AstarPath>().Scan();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
