using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitProgram : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKey("escape"))
        {
			if (SceneManager.GetActiveScene ().name == "ARS_MainMenu") {
				Debug.Log ("Exit");
				Application.Quit ();

			} else {
				SceneManager.LoadScene ("ARS_MainMenu");

			}
        }

    }
}
