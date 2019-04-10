using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

	
	public Transform Target;
	public float turretRange = 50f;

	public string enemyTag = "Enemy";
	public Transform TurretPart;
	public float turnSpeed = 10f;
	
	// Use this for initialization
	void Start () 
	{
		InvokeRepeating("UpdateTarget", 0f, 0.5f); // starting in 0 seconds and execute every 0.5 seconds
	}
	

	void UpdateTarget()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
		float shortestDistance = Mathf.Infinity; 
		GameObject nearestEnemy = null;
		
		foreach(GameObject enemy in enemies)
		{
			float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);	
			if(distanceToEnemy < shortestDistance)
			{
				shortestDistance = distanceToEnemy;
				nearestEnemy = enemy;
			}
		}
		if(nearestEnemy != null && shortestDistance <= turretRange)
		{
			Target = nearestEnemy.transform;
		}

	}


	// Update is called once per frame
	void Update ()
	{
		if(Target == null)
		return;

		Vector3 dir = Target.position - transform.position; // dir = direction
		Quaternion lookRotation = Quaternion.LookRotation(dir);
		Vector3 rotation = Quaternion.Lerp(TurretPart.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles; // <--- eulerAngles = x, y,z.
		TurretPart.rotation = Quaternion.Euler(0f,rotation.y,0f);
	}	


	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, turretRange); // draws lines on turret gameobject.
	}



	
}
