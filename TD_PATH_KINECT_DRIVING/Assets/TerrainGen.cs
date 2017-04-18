using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGen : MonoBehaviour {

	private Vector3[] _Vertices;

	public GameObject prefab ;

	// Use this for initialization
	void Start () {
		GetComponent<MeshFilter> ().mesh = GameObject.Find ("_SandBoxData").GetComponent<SandBoxData> ().ARS_Data.mesh;
		GetComponent<MeshCollider> ().sharedMesh = GetComponent<MeshFilter> ().mesh;
		GameObject.Find ("A_").GetComponent<AstarPath> ().Scan ();

		int a = GetComponent<MeshFilter> ().mesh.vertexCount;
		_Vertices = new Vector3[a];

		_Vertices = GetComponent<MeshFilter> ().mesh.vertices;

		float Counter = 0;


		for (int x = 0; x < 100; x ++)
		{

			int c = 0;
			int d = 0;;
			for (int y = 0; y < 100; y ++)
			{
				

				int smallIndex = (y * 100) + x;
				//Debug.Log (_Vertices [smallIndex].z);
				if (_Vertices [smallIndex].z < -4.8 && _Vertices [smallIndex].z > -5.2) {

					Counter++;

					if ((x % 10 == 0) && (y < 50) && (c < 1)) {
						Counter = 0;
						c++;
						Debug.Log (_Vertices [smallIndex]);
						GameObject Turretplatform = Instantiate (prefab, _Vertices[smallIndex], new Quaternion (0, 0, 0,1));

						Turretplatform.transform.position = new Vector3 (_Vertices[smallIndex].x, -_Vertices[smallIndex].z, -_Vertices[smallIndex].y);

						Turretplatform.transform.localScale = new Vector3 (3, 3, 3);

						Turretplatform.transform.SetParent( GameObject.Find ("TowerSpots").transform);

					

					}

					if ((x % 10 == 0) && (y > 50) && (d < 1)) {
						Counter = 0;
						d++;
						Debug.Log (_Vertices [smallIndex]);
						GameObject Turretplatform = Instantiate (prefab, _Vertices [smallIndex], new Quaternion (0, 0, 0, 1));

						Turretplatform.transform.position = new Vector3 (_Vertices [smallIndex].x, -_Vertices [smallIndex].z, -_Vertices [smallIndex].y);

						Turretplatform.transform.localScale = new Vector3 (3, 3, 3);

						Turretplatform.transform.SetParent (GameObject.Find ("TowerSpots").transform);
					}

				}

			}
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
