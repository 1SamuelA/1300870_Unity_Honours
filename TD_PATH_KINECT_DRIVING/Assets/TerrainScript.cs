using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainScript : MonoBehaviour {

	private Terrain TerrainMesh;

	// Use this for initialization
	void Start () {
		TerrainMesh = GetComponent<Terrain> ();
//		TerrainMesh.terrainData;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
