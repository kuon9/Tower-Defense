using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {


[SerializeField] Transform Unit; // Which tower will do targeting pretty much. 
[SerializeField] float AttackRange = 10f;
[SerializeField] ParticleSystem projectileParticle;  // reference 
 Transform targetEnemy; //you gonna put in the enemy in this slot so our towers look at them..\

	// Update is called once per frame
void Update () 
	{
	   	SetTargetEnemy();
		if(targetEnemy)
		{
		Unit.LookAt(targetEnemy); // tower will look at enemy yee.
		FireAtEnemy();
		}
		else // if enemy is gone then shooting stops yee.
		{
			Shoot(false); 
		}
	}

private void SetTargetEnemy()
	{	
		var sceneEnemies = FindObjectsOfType<EnemyDamage>();// anybody with this script is a damageable enemy.
		if(sceneEnemies.Length == 0) {return ;} // if there aren't any then we get out.
		Transform closestEnemy = sceneEnemies[0].transform; 

		foreach (EnemyDamage testEnemy in sceneEnemies)
		{
			closestEnemy = GetClosest(closestEnemy, testEnemy.transform);
		}
		targetEnemy = closestEnemy;
	}

private Transform GetClosest(Transform transformA, Transform transformB)
	// This method returns the closest transform of the two enemy supplied
	{
		var distToA = Vector3.Distance(transform.position, transformA.position);
		var distToB = Vector3.Distance(transform.position, transformB.position);
		// Distance should be of the transform the script is attached to.
		if(distToA < distToB)
		{
			return transformA;
		}
			return transformB;
	}

private void FireAtEnemy()
	{
		float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);
		if(distanceToEnemy <= AttackRange)
		{
			Shoot(true);
		} 
		else
		{
			Shoot(false);
		}
	}

private void Shoot(bool isActive)
	{
		var emissionModule = projectileParticle.emission;
		emissionModule.enabled = isActive;
	}	

} // end of class
