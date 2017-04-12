using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<MeshFilter> ().mesh = GameObject.Find ("_SandBoxData").GetComponent<SandBoxData> ().ARS_Data.mesh;
		GetComponent<MeshCollider> ().sharedMesh = GetComponent<MeshFilter> ().mesh;
		GameObject.Find ("A_").GetComponent<AstarPath> ().Scan ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
