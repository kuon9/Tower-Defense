using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDamage : MonoBehaviour {

	[SerializeField] Collider collisionMesh;
	[SerializeField] int Health = 6; // can be float too.
	[SerializeField] ParticleSystem hitParticlePrefab;
	[SerializeField] ParticleSystem DeathParticlePrefab;
	[SerializeField] AudioClip EnemyHitSFX;
	[SerializeField] AudioClip EnemyDeathSFX;
	[SerializeField] Text KillingEnemy;
	public int RobloxValue = 100;
	private ScoreKeeper scoreKeeper;

	AudioSource audioSource;
	

private void Start()
	{
		audioSource = GetComponent<AudioSource>();
		scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
	}
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
			audioSource.PlayOneShot(EnemyHitSFX);
		}
 	private void KillEnemy()
		{
		
			var BlowUp = Instantiate(DeathParticlePrefab, transform.position, Quaternion.identity); // makes the particle prefab appear on at the gameobject transform.position.
			BlowUp.Play();
			float DestroyDelay = BlowUp.main.duration; // the  "main.duration" is in the particle system itself.
			Destroy(BlowUp.gameObject, BlowUp.main.duration); // can't just put BlowUp. you gotta put gameobject because it's asking for one.
			// destroy the particle after delay
			AudioSource.PlayClipAtPoint(EnemyDeathSFX, Camera.main.transform.position);
			Destroy(gameObject);
			AddScore();
		}

		 void AddScore()
		{
			scoreKeeper.Score(RobloxValue);
		}
} // end of class.
