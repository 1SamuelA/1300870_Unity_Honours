using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenPath : MonoBehaviour {

    public int Width = 34;
    public int Height = 34;

    public GameObject StartNode;
    public GameObject EndNode;

    Vector3[] pathVertices;

    GameObject map;
    public GameObject Paths;

    // Use this for initialization
    void Start () {
//        map = GameObject.Find("MapMesh");
//        if(map != null)
//        {
//            Debug.Log("Found Map");
//        }
//
//        Mesh mesh = map.GetComponent<MeshFilter>().sharedMesh;
//        if (mesh != null)
//        {
//            Debug.Log("Found Mesh");
//        }
//
//
//        Vector3[] vertices = mesh.vertices;
//        if (vertices != null)
//        {
//            Debug.Log("Found vertices");
//        }
//
//        int PossibleNodeCount = 0;
//        int PossibleStartExit = 0;
//        int PossibleBuildArea = 0;
//
//        int Size = vertices.Length;
//
//
//        //pathVertices = new Vector3[Size];
//
//        pathVertices = mesh.vertices;
//        Vector2 nearestStart, nearestGoal;
//
//
//        // Separtes the Data up
//        nearestStart = new Vector2(0, 0);
//        nearestGoal = new Vector2(0, 0);
//
//        Vector2 nearestStartLEE = new Vector2(0, 0);
//        Vector2 nearestGoalLEE = new Vector2(0, 0);
//
//        Vector3 sPos = StartNode.transform.localPosition;
//        Vector3 ePos = EndNode.transform.localPosition;
//        
//        Vector2 Startpoint = new Vector2(sPos.x, sPos.z);
//        Vector2 Endpoint = new Vector2(ePos.x, ePos.z);
//
//        float NearDistanceStart = Mathf.Infinity;
//        float NearDistanceGoal = Mathf.Infinity;
//
//        for (int y = 0; y < Height; y++)
//        {
//            for (int x = 0; x < Width; x++)
//            {
//                int index = (y * Width) + x;
//
//                pathVertices[index] = vertices[index];
//
//                Vector2 position = new Vector2(x, y);


                ////

                //if (vertices[index].z < -0.1)
                //{
                    
                //    pathVertices[index].z = -1;

                //    Vector3 worldPt =  transform.TransformPoint(vertices[index]);

                //    Vector2 Current = new Vector2(worldPt.x,worldPt.z);

                //    float distGoal = Vector2.Distance(Current, Endpoint);
                //    float distStart = Vector2.Distance(Current, Startpoint);

                    
                //    PossibleStartExit++;
                //    Debug.Log(PossibleStartExit + " Start: " + vertices[index] + index + " " + x +" : " + + y);

                //    if (NearDistanceStart > distStart)
                //    {
                //        NearDistanceStart = distStart;
                //        nearestStart = new Vector2(Current.x, Current.y);
                //        nearestStartLEE = new Vector2(x, y);


                //    }
                //    if (NearDistanceGoal > distGoal)
                //    {
                //        NearDistanceGoal = distGoal;
                //        nearestGoal = new Vector2(Current.x, Current.y);
                //        nearestGoalLEE = new Vector2(x, y);
                //    }

                    


                //}
                //else if ((vertices[index].z < -0.02) && (vertices[index].z >= -0.1)) 
                //{
                //    PossibleNodeCount++;
                //    pathVertices[index].z = 0;
                //}
                //else
                //{
                //    PossibleBuildArea++;
                //    pathVertices[index].z = 1;
                //}
//
//            }
//        }
//
//        
//        mesh.vertices = vertices;
//
//       // Debug.Log("Start: " + Startpoint);
//       // Debug.Log("End  : " + Endpoint);
//
//       // Debug.Log("Start Coord: " + nearestStart);
//       // Debug.Log("End Coord  : " + nearestGoal);
//
//        Debug.Log("Path : " + PossibleNodeCount);
//        Debug.Log("Start: " + PossibleStartExit);
//        Debug.Log("Build: " + PossibleBuildArea);
//        Debug.Log("Total: " + Size);
//        int a = PossibleNodeCount + PossibleStartExit + PossibleBuildArea;
//
//        Debug.Log("Total : " + a);



    }

    // Update is called once per frame
    void Update () {
		
	}
}
