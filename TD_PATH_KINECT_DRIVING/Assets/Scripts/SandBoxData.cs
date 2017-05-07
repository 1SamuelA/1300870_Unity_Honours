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

	public float AstarDepth;

	public Mesh mesh;

}

public class SandBoxData : MonoBehaviour {


	public static SandBoxData instance;

	public  ARS_Calibration_Data ARS_Data;

	void Start()
	{

		if (instance != null) {
			Destroy (this.gameObject);
			return;
		}

        Debug.Log("displays connected: " + Display.displays.Length);
        if (Display.displays.Length > 1)
            Display.displays[1].Activate();

        ARS_Data.SandDepth = new Vector2 (2200f, 2500);
		ARS_Data.InterationDepth = new Vector2 (1400f, 2040);

		ARS_Data.Rot = 0;

		ARS_Data.DepthImageConfig_LRTB = new Vector4 (162f, 343, 305, 126);
		ARS_Data.CameraPosition = new Vector4 (-5f, 0, 50, 0);

		//If it gets here then this is the only one.
		instance = this; 									// There can be only one
		GameObject.DontDestroyOnLoad (this.gameObject);		//
	}


	public void LoadNewScene(string SceneName)
	{
		Debug.Log (SceneName);
		Application.LoadLevel(SceneName);


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