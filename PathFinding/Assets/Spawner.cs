using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject spawnPreFab;
    public GameObject Goal;
    float CDTimer = 0.0f;
    float CDTime = 0.5f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        CDTimer -= Time.deltaTime;

        if(CDTimer <= 0)
        {
            CDTimer = CDTime;

            GameObject bulletGO = (GameObject)Instantiate(spawnPreFab, this.transform.position, this.transform.rotation);

            AIPathFinder b = bulletGO.GetComponent<AIPathFinder>();
            b.target = Goal.transform;
        }

    }
}
