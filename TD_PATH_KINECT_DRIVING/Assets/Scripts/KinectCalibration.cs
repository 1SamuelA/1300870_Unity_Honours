using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KinectCalibration : MonoBehaviour {

	int CalibrationState = 0;
	public GameObject MainCamera;
	public GameObject gameObjectData;
	public SandBoxData gameData;

	public bool debug = false;
    private bool Calibrate = false;

	public Text CalibrationText;
	// Use this for initialization
	void Start () {
		
		gameObjectData = GameObject.Find("_SandBoxData");
		gameData = gameObjectData.GetComponent<SandBoxData> ();
		if (gameData == null) {
			Debug.Log ("gameData == null");
		}

		MainCamera = GameObject.Find("Main Camera");

	}

	void OnGUI()
	{
		if (debug) {
			GUI.BeginGroup (new Rect (0, 0, Screen.width, Screen.height));
			GUI.TextField (new Rect (Screen.width - 600, 10, 250, 20), "CameraPos : " + gameData.ARS_Data.CameraPosition.ToString ());
			GUI.TextField (new Rect (Screen.width - 600, 30, 250, 20), "Rot       : " + gameData.ARS_Data.Rot.ToString ());
			GUI.TextField (new Rect (Screen.width - 600, 50, 250, 20), "DepthImage: " + gameData.ARS_Data.DepthImageConfig_LRTB.ToString ());
			GUI.TextField (new Rect (Screen.width - 600, 70, 250, 20), "SandDepth : " + gameData.ARS_Data.SandDepth.ToString ());
			GUI.TextField (new Rect (Screen.width - 600, 90, 250, 20), "DepthMode : " + gameData.ARS_Data.InterationDepth.ToString ());

			GUI.EndGroup ();
		}
	}
    // Update is called once per frame
    void Update()
    {

        if (Calibrate)
        {
            DoCalibration();
        }


        if(Input.GetKeyDown("p"))
        {
            Calibrate = !Calibrate;
        }

    }

        
		

    void DoCalibration()
    {

        switch (CalibrationState)
        {


            case 0:
                {
                    // Camera Rotation
                    if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        Debug.Log(gameData.ARS_Data.Rot);
                        gameData.ARS_Data.Rot += 90;
                    }
                    else if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        gameData.ARS_Data.Rot -= 90;
                    }
                    if (CalibrationText != null)
                        CalibrationText.text = CalibrationState.ToString() + ": Camera Rotation";
                    break;
                }
            case 1:
                {

                    if (Input.GetKeyDown(KeyCode.D))
                    {
                        gameData.ARS_Data.DepthImageConfig_LRTB.x++;
                        Debug.Log("D: " + gameData.ARS_Data.DepthImageConfig_LRTB.x);
                    }
                    else if (Input.GetKeyDown(KeyCode.A))
                    {
                        gameData.ARS_Data.DepthImageConfig_LRTB.x--;
                        Debug.Log("A: " + gameData.ARS_Data.DepthImageConfig_LRTB.x);
                    }

                    if (Input.GetKeyDown(KeyCode.W))
                    {
                        gameData.ARS_Data.DepthImageConfig_LRTB.y++;
                    }
                    else if (Input.GetKeyDown(KeyCode.S))
                    {
                        gameData.ARS_Data.DepthImageConfig_LRTB.y--;
                    }

                    if (Input.GetKeyDown(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
                    {
                        gameData.ARS_Data.DepthImageConfig_LRTB.x += 10;
                        Debug.Log("D: " + gameData.ARS_Data.DepthImageConfig_LRTB.x);
                    }
                    else if (Input.GetKeyDown(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
                    {
                        gameData.ARS_Data.DepthImageConfig_LRTB.x -= 10;
                        Debug.Log("A: " + gameData.ARS_Data.DepthImageConfig_LRTB.x);
                    }

                    if (Input.GetKeyDown(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
                    {
                        gameData.ARS_Data.DepthImageConfig_LRTB.y += 10;
                    }
                    else if (Input.GetKeyDown(KeyCode.S) && Input.GetKey(KeyCode.LeftShift))
                    {
                        gameData.ARS_Data.DepthImageConfig_LRTB.y -= 10;
                    }

                    CalibrationText.text = CalibrationState.ToString() + ": Terrain Image Width";
                    break;
                }
            case 2:
                {
                    if (Input.GetKeyDown(KeyCode.D))
                    {
                        gameData.ARS_Data.DepthImageConfig_LRTB.z++;
                    }
                    else if (Input.GetKeyDown(KeyCode.A))
                    {
                        gameData.ARS_Data.DepthImageConfig_LRTB.z--;
                    }

                    if (Input.GetKeyDown(KeyCode.W))
                    {
                        gameData.ARS_Data.DepthImageConfig_LRTB.w++;
                    }
                    else if (Input.GetKeyDown(KeyCode.S))
                    {
                        gameData.ARS_Data.DepthImageConfig_LRTB.w--;
                    }
                    CalibrationText.text = CalibrationState.ToString() + ": Terrain Image Height";
                    break;
                }
            case 3:
                {
                    if (Input.GetKeyDown(KeyCode.D))
                    {
                        gameData.ARS_Data.CameraPosition.x++;
                    }
                    else if (Input.GetKeyDown(KeyCode.A))
                    {
                        gameData.ARS_Data.CameraPosition.x--;
                    }

                    if (Input.GetKeyDown(KeyCode.W))
                    {
                        gameData.ARS_Data.CameraPosition.y++;
                    }
                    else if (Input.GetKeyDown(KeyCode.S))
                    {
                        gameData.ARS_Data.CameraPosition.y--;
                    }
                    CalibrationText.text = CalibrationState.ToString() + ": Camera Position";
                    break;
                }
            case 4:
                {
                    if (Input.GetKeyDown(KeyCode.D))
                    {
                        gameData.ARS_Data.CameraPosition.z++;
                    }
                    else if (Input.GetKeyDown(KeyCode.A))
                    {
                        gameData.ARS_Data.CameraPosition.z--;
                    }

                    if (Input.GetKeyDown(KeyCode.W))
                    {
                        gameData.ARS_Data.CameraPosition.w++;
                    }
                    else if (Input.GetKeyDown(KeyCode.S))
                    {
                        gameData.ARS_Data.CameraPosition.w--;
                    }
                    CalibrationText.text = CalibrationState.ToString() + ": Camera Size";
                    break;
                }
            case 5:
                {
                    if (Input.GetKeyDown(KeyCode.D))
                    {
                        gameData.ARS_Data.SandDepth.x--;
                    }
                    else if (Input.GetKeyDown(KeyCode.A))
                    {
                        gameData.ARS_Data.SandDepth.x++;
                    }

                    if (Input.GetKeyDown(KeyCode.W))
                    {
                        gameData.ARS_Data.SandDepth.y--;
                    }
                    else if (Input.GetKeyDown(KeyCode.S))
                    {
                        gameData.ARS_Data.SandDepth.y++;
                    }
                    CalibrationText.text = CalibrationState.ToString() + ": SandDepth";
                    break;
                }
            default:
                CalibrationText.text = CalibrationState.ToString();
                break;
        }



        if (Input.GetKeyDown(KeyCode.V))
        {
            CalibrationState++;
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            if (CalibrationState > 0)
                CalibrationState--;
        }

        UpdateScene();

    }
    

	void UpdateScene()
	{

		MainCamera.transform.position = new Vector3 (gameData.ARS_Data.CameraPosition.x, MainCamera.transform.position.y, gameData.ARS_Data.CameraPosition.y);

		Transform a = MainCamera.transform;
		a.eulerAngles = new Vector3( MainCamera.transform.eulerAngles.x ,gameData.ARS_Data.Rot, MainCamera.transform.eulerAngles.z );


		MainCamera.transform.eulerAngles = new Vector3( 
			MainCamera.transform.eulerAngles.x , 
			gameData.ARS_Data.Rot,
			MainCamera.transform.eulerAngles.z
			);


		Camera Ca = MainCamera.GetComponent<Camera> ();
		Ca.orthographicSize = gameData.ARS_Data.CameraPosition.z;

	}

	public void ScanTheTerrain()
	{
		GameObject AStar = GameObject.Find ("A_");

		AStar.GetComponent<A_Scan> ().Click ();
	}

}
