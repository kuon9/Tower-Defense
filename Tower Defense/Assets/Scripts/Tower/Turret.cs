using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

	private Transform Target;
	
	[Header("Attributes")]
	[SerializeField] float turretRange = 50f;
	[SerializeField] float turnSpeed = 10f;
	[SerializeField] float fireRate = 1f;
	[SerializeField] float DelaybetweenFire = 0f;
	
	[Header("Unity Setup Fields")]
	public string enemyTag = "Enemy";
	
	
	[SerializeField] Transform TurretPart;
	[SerializeField] ParticleSystem bulletPrefab;
	[SerializeField] Transform firePoint;
	
	
	// Use this for initialization
	void Start () 
	{
		InvokeRepeating("UpdateTarget", 0f, 0.5f); // starting in 0 seconds and execute every 0.5 seconds
	}
	

	void UpdateTarget()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag); // array of enemies. Attach enemy tag to the gameobjects
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
		// 4 line of codes above is our Target Lock-on.

		if(DelaybetweenFire <= 0)
		{
			Shoot();
			DelaybetweenFire = 1f/fireRate;
		}
			DelaybetweenFire -= Time.deltaTime; // means minus 1 after executing.
			// above means DelayBetweenfire = DelayBetweenfire - Time.deltaTime;
	}		


	void Shoot()
	{
	ParticleSystem BulletYEET = (ParticleSystem) Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
	Bullet bullet = BulletYEET.GetComponent<Bullet>();

	if(bullet != null)
	bullet.Seek(Target);

	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, turretRange); // draws lines on turret gameobject.
	}



	
}
