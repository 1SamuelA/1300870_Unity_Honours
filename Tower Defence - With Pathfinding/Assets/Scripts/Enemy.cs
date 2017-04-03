using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    GameObject pathGO;


    Transform targetPathNode;
    int pathNodeIndex = 0;

    public float speed = 5f;
    public float health = 1f;
    public int moneyValue = 1;

	// Use this for initialization
	void Start () {
        pathGO = GameObject.Find("Path");
	}
	
    void GetNextPathNode()
    {
        try 
        {
            targetPathNode = pathGO.transform.GetChild(pathNodeIndex);
            pathNodeIndex++;
        }
        catch
        {
            targetPathNode = null;
        }
        
        
    }

	// Update is called once per frame
	void Update () {
		if(targetPathNode == null)
        {
            GetNextPathNode();
            if(targetPathNode == null)
            {
                ReachedGoal();
                return;
            }
        }

        Vector3 dir = targetPathNode.transform.position - this.transform.position;

        float distThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distThisFrame)
        {
            targetPathNode = null;
        }
        else
        {
            transform.Translate(dir.normalized * distThisFrame, Space.World);
            Quaternion targetTransform = Quaternion.LookRotation(dir);
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetTransform, Time.deltaTime*5);
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
