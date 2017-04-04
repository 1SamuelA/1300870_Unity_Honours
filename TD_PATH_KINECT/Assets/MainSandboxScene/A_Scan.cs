using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class A_Scan : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire2")) {
			AstarPath aSP = GetComponent<AstarPath> ();

			AstarData aSD = aSP.astarData;

			GridGraph gg = aSD.FindGraphOfType(typeof(GridGraph)) as GridGraph;

			if (gg != null) {
				Debug.Log (gg.collision.fromHeight);
				Debug.Log (gg.name);
			}

			AstarPath.active.Scan ();
		}
	}
}
