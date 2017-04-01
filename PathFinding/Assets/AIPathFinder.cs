using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AIPathFinder : MonoBehaviour {

    public Transform target;

    Seeker seeker;
    Path path;
    int currentWaypoint;

    public float speed = 20;
    CharacterController characterController;

	// Use this for initialization
	void Start () {
        seeker = GetComponent<Seeker>();
        seeker.StartPath(transform.position, target.position, OnPathComplete);
        characterController = GetComponent<CharacterController>();

    }

    public void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
        else
        {
            Debug.Log(p.error);
        }
    }

	// Update is called once per frame
	void FixedUpdate () {
		if(path == null)
        {
            return;
        }

        if (currentWaypoint >= path.vectorPath.Count)
        {
            Destroy(gameObject);
            return;
        }

        
        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized * speed;

        Quaternion lookRot = Quaternion.LookRotation(dir);

        transform.rotation = lookRot;

        characterController.SimpleMove(dir);

        if (Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]) < 1) {
            currentWaypoint++;
        }

        

    }
}
