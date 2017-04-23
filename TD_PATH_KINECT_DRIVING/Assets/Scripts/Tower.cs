using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tower : MonoBehaviour {

    Transform turretTransfom;

    
    public GameObject bulletPrefab;
    public int cost = 5;

    public float range = 10f;
    public float fireCooldown = 0.5f;
    float fireCooldownLeft = 0f;

	public float BulletSpeed = 15;

    public float Damage = 1;
    public float DamageRadius = 0f;
	// Use this for initialization
	void Start () {
       turretTransfom = transform.Find("Turret");  

    }
	
	// Update is called once per frame
	void Update () {

		AIPathFinder[] enemies = GameObject.FindObjectsOfType<AIPathFinder>();

		AIPathFinder nearestEnemy = null;
        float dist = Mathf.Infinity;

		foreach(AIPathFinder e in enemies)
        {
            float d = Vector3.Distance(this.transform.position, e.transform.position);
            if(nearestEnemy == null || d < dist)
            {
                nearestEnemy = e;
                dist = d;
            }
        }

        if(nearestEnemy == null)
        {
            Debug.Log("No Enemies");
            return;
        }

        Vector3 a = nearestEnemy.transform.position;
        Vector3 b = this.transform.position;
        Vector3 dir = a - b;

        Quaternion lookRot = Quaternion.LookRotation(dir);

        turretTransfom.rotation = Quaternion.Euler(0, lookRot.eulerAngles.y, 0);

        fireCooldownLeft -= Time.deltaTime;
        if (fireCooldownLeft <= 0 && dir.magnitude <= range )
        {
            fireCooldownLeft = fireCooldown;
            ShootAt(nearestEnemy);
        }

    }

	void ShootAt(AIPathFinder e)
    {
        
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, turretTransfom.GetChild(0).GetChild(0).transform.position, turretTransfom.rotation);

        Bullet b = bulletGO.GetComponent<Bullet>();
        b.target = e.transform;
        b.targetE = e;
        b.damage = Damage;
        b.radius = DamageRadius;
		b.speed = BulletSpeed;
    }

}
