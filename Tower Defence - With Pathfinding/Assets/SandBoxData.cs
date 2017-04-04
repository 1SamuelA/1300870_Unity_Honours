using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public struct ARS_Calibration_Data
{
	public Vector2 SandDepth;
	public Vector2 InterationDepth;

	public int Rot;

	public Vector4 DepthImageConfig_LRTB;

	public Vector4 CameraPosition;
	public Vector4 CameraScale;

}

public class SandBoxData : MonoBehaviour {


	public static SandBoxData instance;

	public ARS_Calibration_Data ARS_Data;

	void Start()
	{

		if (instance != null) {
			Destroy (this.gameObject);
			return;
		}

		ARS_Data.SandDepth = new Vector2 (2240f, 2462);
		ARS_Data.InterationDepth = new Vector2 (1600f, 2040);

		ARS_Data.Rot = 180;

		ARS_Data.DepthImageConfig_LRTB = new Vector4 (159f, 345, 322, 106);

		//If it gets here then this is the only one.
		instance = this; 									// There can be only one
		GameObject.DontDestroyOnLoad (this.gameObject);		//
	}


	public void LoadNewScene(string SceneName)
	{
		SceneManager.LoadScene(SceneName, LoadSceneMode.Single);


	}



	void SetSandDepth(float min, float max)
	{
		ARS_Data.SandDepth.x = min;
		ARS_Data.SandDepth.y = max;
	}

	void SetSandDepth(Vector2 minmax)
	{
		ARS_Data.SandDepth = minmax;
	}

	void SetInterationDepth(float min, float max)
	{
		ARS_Data.InterationDepth.x = min;
		ARS_Data.InterationDepth.y = max;
	}

	void SetInterationDepth(Vector2 minmax)
	{
		ARS_Data.InterationDepth = minmax;
	}
	// Update is called once per frame
}