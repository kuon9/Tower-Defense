using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	[SerializeField] List<Block> path;


	// Use this for initialization
	void Start () {
		PrintAllWayPoints();
	}
	
	private void PrintAllWayPoints()
	{
		foreach (Block waypoint in path) // Block becomes waypoint
		{
			print(waypoint.name); // name of each cube appear in console.
		}
	}


	// Update is called once per frame
	void Update () {
		
	}
}
