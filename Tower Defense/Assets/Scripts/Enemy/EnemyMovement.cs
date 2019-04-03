using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {



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
			yield return new WaitForSeconds(2f); // Taking 2 seconds to move from block to block.
		}
			print("Ending Patrol");
	}


	// Update is called once per frame
	void Update () {
		
	}
}
