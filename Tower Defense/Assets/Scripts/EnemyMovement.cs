﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	[SerializeField] List<WayPoints> path;


	// Use this for initialization
	void Start () {
		StartCoroutine(FollowPath());
	}
	
	IEnumerator FollowPath()
	{
		print("Starting Patrol");
		foreach (WayPoints waypoint in path) // Block becomes waypoint
		{
			transform.position = waypoint.transform.position;
			print("Visiting" + waypoint);	
			yield return new WaitForSeconds(1f);
		}
			print("Ending Patrol");
	}


	// Update is called once per frame
	void Update () {
		
	}
}
