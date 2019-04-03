using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

	[SerializeField] Collider collisionMesh;
	[SerializeField] int Health = 6; // can be float too.
	[SerializeField] ParticleSystem hitParticlePrefab;
	[SerializeField] ParticleSystem DeathParticlePrefab;

/// OnParticleCollision is called when a particle hits a collider.
/// </summary>
/// <param name="other">The GameObject hit by the particle.</param>
	
	
	private	void OnParticleCollision(GameObject other) // particle hitting the gameobject.
		{
			ProcessHit(); // this activates when the particle collide with the gameobject.
			if(Health <= 0)
			{
				KillEnemy();
			}
		}
	void ProcessHit()
		{
			Health = Health - 1;
			print("current hitpoints are " + Health);
			hitParticlePrefab.Play(); // this plays our particle system when process hit triggers.
	
		}
 	private void KillEnemy()
		{
			var BlowUp = Instantiate(DeathParticlePrefab, transform.position, Quaternion.identity); // makes the particle prefab appear on at the gameobject transform.position.
			BlowUp.Play();
			float DestroyDelay = BlowUp.main.duration; // the duration is in the particle system itself.

			Destroy(BlowUp.gameObject, BlowUp.main.duration); // can't just put BlowUp. you gotta put gameobject because it's asking for one.
			// destroy the particle after delay
			Destroy(gameObject);
		}
} // end of class.
