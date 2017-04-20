using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControllerScript : MonoBehaviour {

    public float maxTorque = 50;
    public float steerForce = 2;

    public enum DriveMode { Front, Rear, All };
    public DriveMode driveMode = DriveMode.Rear;

    public Transform CofM;

    public WheelCollider[] wheelColliders = new WheelCollider[4];
    public Transform[] TireMesh = new Transform[4];

    
    private Rigidbody m_Rigidbody;

    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Rigidbody.centerOfMass = CofM.localPosition;
    }

    void UpdateMeshesPostion()
    {
        for(int i = 0; i < 4;i++)
        {
            Quaternion quat;
            Vector3 pos;
            wheelColliders[i].GetWorldPose(out pos, out quat);

            TireMesh[i].position = pos;
            TireMesh[i].rotation = quat;

        }

    }

    void Update()
    {
        UpdateMeshesPostion();
    }

    void FixedUpdate()
    {



        float steer = Input.GetAxis("Horizontal");
        float acceleration = Input.GetAxis("Vertical");

        float FinalAngle = 45 * steer;
        wheelColliders[0].steerAngle = FinalAngle;
        wheelColliders[1].steerAngle = FinalAngle;

        float scaledTorque = acceleration * maxTorque;

        if (driveMode == DriveMode.All)
        {
            wheelColliders[0].motorTorque = scaledTorque;
            wheelColliders[1].motorTorque = scaledTorque;
            wheelColliders[2].motorTorque = scaledTorque;
            wheelColliders[3].motorTorque = scaledTorque;

        }
        else
        {

            wheelColliders[0].motorTorque = ((driveMode == DriveMode.Rear) || (driveMode == DriveMode.All)) ? 0 : scaledTorque;
            wheelColliders[1].motorTorque = ((driveMode == DriveMode.Rear) || (driveMode == DriveMode.All)) ? 0 : scaledTorque;
            wheelColliders[2].motorTorque = ((driveMode == DriveMode.Front) || (driveMode == DriveMode.All)) ? 0 : scaledTorque;
            wheelColliders[3].motorTorque = ((driveMode == DriveMode.Front) || (driveMode == DriveMode.All)) ? 0 : scaledTorque;

        }




    }

}
