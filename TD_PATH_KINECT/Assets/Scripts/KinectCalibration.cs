using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinectCalibration : MonoBehaviour {

	int CalibrationState = 0;
	public GameObject A;
	public SandBoxData gameData;
	// Use this for initialization
	void Start () {
		
		gameData = FindObjectOfType<SandBoxData> ();
		if (gameData == null) {
			Debug.Log ("gameData == null");
		}
	}
	
	// Update is called once per frame
	void Update () {
		switch (CalibrationState)
		{
		case 0:
			{
				if (Input.GetKeyDown (KeyCode.RightArrow)) {
					gameData.ARS_Data.Rot += 90;
				}
				else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
					gameData.ARS_Data.Rot -= 90;
				}
				break;
			}
		case 1:
			{
				if (Input.GetKeyDown (KeyCode.D)) {
					gameData.ARS_Data.DepthImageConfig_LRTB.x += 90;
				}
				else if (Input.GetKeyDown (KeyCode.A)) {
					gameData.ARS_Data.DepthImageConfig_LRTB.x -= 90;
				}

				if (Input.GetKeyDown (KeyCode.W)) {
					gameData.ARS_Data.DepthImageConfig_LRTB.y += 90;
				}
				else if (Input.GetKeyDown (KeyCode.S)) {
					gameData.ARS_Data.DepthImageConfig_LRTB.y -= 90;
				}
				break;
			}
		case 2:
			break;
		default:
			break;
		}

		if (Input.GetKeyDown (KeyCode.V)) {
			CalibrationState++;
		}
		else if (Input.GetKeyDown (KeyCode.C)) {
			if(CalibrationState>0)
				CalibrationState--;
		}

	}
}
