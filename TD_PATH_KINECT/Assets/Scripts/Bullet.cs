﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 15;

    public Transform target;
	public AIPathFinder targetE;
    public float damage = 1;
    public float radius = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.transform.position - this.transform.position;

        float distThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distThisFrame)
        {
            DoBulletHit();
        }
        else
        {
            transform.Translate(dir.normalized * distThisFrame, Space.World);
            Quaternion targetTransform = Quaternion.LookRotation(dir);
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetTransform, Time.deltaTime);
        }

    }


    void DoBulletHit()
    {

        if(radius == 0)
        {
            targetE.takeDamage(damage);
            
        }
        else
        {
            Collider[] cols = Physics.OverlapSphere(transform.position, radius);

            foreach(Collider c in cols)
            {
				AIPathFinder e = c.GetComponent<AIPathFinder>();
                if(e != null)
                {
					e.GetComponent<AIPathFinder>().takeDamage(damage);
                }
            }

        }
        
        Destroy(gameObject);
    }

}
