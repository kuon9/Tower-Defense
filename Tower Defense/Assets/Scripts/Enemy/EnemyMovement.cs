using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {


	[SerializeField] float movementPeriod = .5f;
	[SerializeField] ParticleSystem boomParticle;

	// Use this for initialization
	void Start () 
	{
	    PathFinder pathfinder = FindObjectOfType<PathFinder>();
		var path = pathfinder.GetPath(); // var saves us a lot of time because we use it to define long ass words yee
		StartCoroutine(FollowPath(path));
	}
	
	IEnumerator FollowPath(List<WayPoint> path)
	{
		print("Starting Patrol");
		foreach (WayPoint waypoint in path) // Block becomes waypoint
		{
			transform.position = waypoint.transform.position;	
			yield return new WaitForSeconds(movementPeriod); // Taking 2 seconds to move from block to block.
		}
			SelfDestruct(); // end of path.
	}

	private void SelfDestruct()
	{
		var BlowUp = Instantiate(boomParticle, transform.position, Quaternion.identity); // makes the particle prefab appear on at the gameobject transform.position.
		BlowUp.Play();
		float DestroyDelay = BlowUp.main.duration; // the duration is in the particle system itself.
		Destroy(BlowUp.gameObject, BlowUp.main.duration); // can't just put BlowUp. you gotta put gameobject because it's asking for one.
		// destroy the particle after delay
		Destroy(gameObject);
	}

}
