using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {


[SerializeField] Transform Unit; // Which tower will do targeting pretty much. 
[SerializeField] Transform targetEnemy; //you gonna put in the enemy in this slot so our towers look at them..\
[SerializeField] float AttackRange = 10f;
[SerializeField] ParticleSystem projectileParticle;  // reference 

	// Update is called once per frame
	void Update () {
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
