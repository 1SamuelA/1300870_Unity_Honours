using UnityEngine;
using System.Collections;
using Windows.Kinect;



public class CarDepth : MonoBehaviour
{

    public GameObject ColorSourceManager;
    public GameObject DepthSourceManager;
    public GameObject MultiSourceManager;

    public GameObject Car; 
	public float CarUpdateDistance = 10;

    private KinectSensor _Sensor;
    private CoordinateMapper _Mapper;
    private Mesh _Mesh;
    private Vector3[] _Vertices;
    private Vector2[] _UV;
    private int[] _Triangles;

	public bool updateTerrain = true;
    
    // Only works at 4 right now
    private const int _DownsampleSize = 4;
    private const double _DepthScale = 0.05f;
    private const int _Speed = 50;
    
    private MultiSourceManager _MultiManager;
    private ColorSourceManager _ColorManager;
    private DepthSourceManager _DepthManager;

	public int MeshWidth = 100;
	public int MeshHeight = 100;

	public SandBoxData gameData;

	public Vector2 DepthCutOff;
	public float Mode;

	void Start()
    {
        _Sensor = KinectSensor.GetDefault();
        if (_Sensor != null)
        {
            _Mapper = _Sensor.CoordinateMapper;
            var frameDesc = _Sensor.DepthFrameSource.FrameDescription;

            // Downsample to lower resolution
			CreateMesh(MeshWidth, MeshHeight);


			this.transform.position = new Vector3 (0, 0, 0);

            if (!_Sensor.IsOpen)
            {
                _Sensor.Open();
            }
        }

		gameData = FindObjectOfType<SandBoxData> ();

		//if (gameData == default(ProportionPoint)) {
		//	Debug.Log ("gameData == null");
		//}



    }

    void CreateMesh(int width, int height)
    {
        _Mesh = new Mesh();
		_Mesh.name = this.name+"Mesh";
        GetComponent<MeshFilter>().mesh = _Mesh;

        _Vertices = new Vector3[width * height];
        _UV = new Vector2[width * height];
        _Triangles = new int[6 * ((width - 1) * (height - 1))];

        int triangleIndex = 0;
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                int index = (y * width) + x;

				_Vertices[index] = new Vector3(x - 50 , -y +50 , 0);
                _UV[index] = new Vector2(((float)x / (float)width), ((float)y / (float)height));

                // Skip the last row/col
                if (x != (width - 1) && y != (height - 1))
                {
                    int topLeft = index;
                    int topRight = topLeft + 1;
                    int bottomLeft = topLeft + width;
                    int bottomRight = bottomLeft + 1;

                    _Triangles[triangleIndex++] = topLeft;
                    _Triangles[triangleIndex++] = topRight;
                    _Triangles[triangleIndex++] = bottomLeft;
                    _Triangles[triangleIndex++] = bottomLeft;
                    _Triangles[triangleIndex++] = topRight;
                    _Triangles[triangleIndex++] = bottomRight;
                }
            }
        }

        _Mesh.vertices = _Vertices;
        _Mesh.uv = _UV;
        _Mesh.triangles = _Triangles;
        _Mesh.RecalculateNormals();
    }
    
    void OnGUI()
    {
        GUI.BeginGroup(new Rect(0, 0, Screen.width, Screen.height));
        //GUI.TextField(new Rect(Screen.width - 250 , 10, 250, 20), "DepthMode: " + ViewMode.ToString());
        GUI.EndGroup();
    }

    void Update()
    {
        if (_Sensor == null)
        {
            return;
        }
        


		if (Input.GetButtonDown ("Fire1")) {

			if (updateTerrain == true) {
				updateTerrain = false;
			} else {
				updateTerrain = true;
			}
		}
//
//
//
//            if(ViewMode == DepthViewMode.MultiSourceReader)
//            {
//                ViewMode = DepthViewMode.SeparateSourceReaders;
//            }
//            else
//            {
//                ViewMode = DepthViewMode.MultiSourceReader;
//            }
//        }
        
        float yVal = Input.GetAxis("Horizontal");
        float xVal = -Input.GetAxis("Vertical");

		//transform.Rotate (xVal, yVal, 0.0f);
        
		if (updateTerrain == true) 
		{
			
			
			if (MultiSourceManager == null) {
				return;
			} 

			_MultiManager = MultiSourceManager.GetComponent<MultiSourceManager>();
			if (_MultiManager == null)
			{
				return;
			}

			gameObject.GetComponent<Renderer>().material.mainTexture = _MultiManager.GetColorTexture();

			RefreshData(_MultiManager.GetDepthData(),
				_MultiManager.ColorWidth,
				_MultiManager.ColorHeight);
			

		}

		UpdateTransform ();
        
    }
    
//	void Upd()
//	{
//		Transform CarTransform = Car.transform;
//		for (int y = 0; y < MeshHeight; y++) {
//			for (int x = 0; x < MeshWidth; x++) {
//				int smallIndex = (y * MeshWidth) + x;
//				Vector2 CarPos = new Vector2 ((int)CarTransform.position.x, (int)CarTransform.position.z);
//				Vector2 VertPos2 =new  Vector2 (x-50, y-50);
//				float Distance = Vector2.Distance (CarPos, VertPos2);
//
//
//				if (CarUpdateDistance >= Distance) {
//					_Vertices [smallIndex].z = -10;
//				} else {
//					_Vertices [smallIndex].z = 10;
//				}
//			}
//		}
//
//		MeshCollider myMC = GetComponent<MeshCollider>();
//		_Mesh.vertices = _Vertices;
//		_Mesh.uv = _UV;
//		_Mesh.triangles = _Triangles;
//		_Mesh.RecalculateNormals();
//		_Mesh.RecalculateBounds();
//		myMC.sharedMesh = _Mesh;
//	}

    private void RefreshData(ushort[] depthData, int colorWidth, int colorHeight)
    {
		gameData = FindObjectOfType<SandBoxData> ();

        var frameDesc = _Sensor.DepthFrameSource.FrameDescription;

		ColorSpacePoint[] colorSpace = new ColorSpacePoint[depthData.Length];

		float increment_x, increment_y;

		increment_x = (gameData.ARS_Data.DepthImageConfig_LRTB.y - gameData.ARS_Data.DepthImageConfig_LRTB.x) / MeshWidth; //frameDesc.Height / MeshHeight;
		increment_y = (gameData.ARS_Data.DepthImageConfig_LRTB.z - gameData.ARS_Data.DepthImageConfig_LRTB.w) / MeshHeight; //frameDesc.Height / MeshHeight;

		if (Mode == 0) {
			DepthCutOff = gameData.ARS_Data.SandDepth;
		} else {
			DepthCutOff = gameData.ARS_Data.InterationDepth;
		}

		Transform CarTransform = Car.transform;

		for (int y = 0; y < MeshHeight; y ++)
        {
			for (int x = 0; x < MeshWidth; x ++)
            {
				int smallIndex = (y * MeshWidth) + x;
				Vector2 CarPos = new Vector2 ((int)CarTransform.position.x, (int)CarTransform.position.z);
				Vector2 VertPos2 =new  Vector2 (x-50, y-50);
				float Distance = Vector2.Distance (CarPos, VertPos2);

				if (CarUpdateDistance < Distance) {
					
					int indexX = (int)gameData.ARS_Data.DepthImageConfig_LRTB.x + (int)(x * increment_x);
					int indexY = (int)gameData.ARS_Data.DepthImageConfig_LRTB.w + (int)(y * increment_y);
					int bigIndex = (indexY * frameDesc.Width) + indexX;


					double avg;
					if (Mode == 0) {
					

						if ((depthData [bigIndex] >= DepthCutOff.x) && (depthData [bigIndex] < DepthCutOff.y)) {
							avg = depthData [bigIndex];

							avg *= _DepthScale;
							avg -= 125;
							_Vertices [smallIndex].z = (float)avg;
						} 



					} else {
						if ((depthData [bigIndex] >= DepthCutOff.x) && (depthData [bigIndex] < DepthCutOff.y)) {
							avg = depthData [bigIndex];

							avg *= _DepthScale;
							_Vertices [smallIndex].z = (float)(avg - 125);
						} else {
							_Vertices [smallIndex].z = 0f;
						}
					}


					// Update UV mapping with CDRP
					var colorSpacePoint = colorSpace [(y * frameDesc.Width) + x];
					_UV [smallIndex] = new Vector2 ((int)gameData.ARS_Data.DepthImageConfig_LRTB.x + (colorSpacePoint.X / (float)(colorWidth * MeshHeight)),
						(int)gameData.ARS_Data.DepthImageConfig_LRTB.w + (colorSpacePoint.Y / (float)(colorHeight * MeshHeight)));
				} else {
					
				}
            }
        }
        

        

		MeshCollider myMC = GetComponent<MeshCollider>();
		_Mesh.vertices = _Vertices;
		_Mesh.uv = _UV;
		_Mesh.triangles = _Triangles;
		_Mesh.RecalculateNormals();
		_Mesh.RecalculateBounds();
		myMC.sharedMesh = _Mesh;

    }

    void OnApplicationQuit()
    {
        if (_Mapper != null)
        {
            _Mapper = null;
        }
        
        if (_Sensor != null)
        {
            if (_Sensor.IsOpen)
            {
                _Sensor.Close();
            }

            _Sensor = null;
        }
    }

	void UpdateTransform()
	{
		//this.transform.Rotate (0, 90, 0);

		//this.transform.rotation 
		//Debug.Log (gameData.ARS_Data.Rot);
	}
		
}

