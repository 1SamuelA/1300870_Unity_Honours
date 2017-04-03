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
	public float health = 1f;
	public int moneyValue = 1;
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
			ReachedGoal();
            return;
        }

        
        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized * speed;

        Quaternion lookRot = Quaternion.LookRotation(dir);

        transform.rotation = Quaternion.Lerp(this.transform.rotation, lookRot, Time.deltaTime * 5);

        characterController.SimpleMove(dir);

        if (Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]) < 1) {
            currentWaypoint++;
        }
			
    }

	void ReachedGoal()
	{
		Debug.Log(" ReachGoal");
		GameObject.FindObjectOfType<ScoreManager>().loseLife();
		Destroy(this.gameObject);
	}

	public void takeDamage(float damage)
	{
		health -= damage;
		if(health <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		GameObject.FindObjectOfType<ScoreManager>().money += moneyValue;
		Destroy(this.gameObject);
	}
}
