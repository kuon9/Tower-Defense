﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour {

	// start from bottom and go up when fixing unity errors yee.

	[SerializeField] WayPoint  startWaypoint, endWaypoint; // two gameobject tabs in inspector, this allows me to drag which cube i want to be start and end.
	Dictionary<Vector2Int, WayPoint> grid = new Dictionary<Vector2Int, WayPoint>();
	
	Vector2Int[] directions = 
	{
		Vector2Int.up,
		Vector2Int.down,
		Vector2Int.right,
		Vector2Int.left
	}; 

	// Use this for initialization
	void Start () {
		LoadCubes();
		ColorStartAndEnd();
		ExploreNeighbours();
	}


	private void ExploreNeighbours()
	{	
		foreach(Vector2Int direction in directions)
		{
			Vector2Int explorationCoordinates = startWaypoint.GetGridPosition() + direction;
			try // trys executing this and if there's a problem,
			// then it will do whatever we well it to do with catch
			{
			grid[explorationCoordinates].SetTopColor(Color.black);// sets the area we're exploring into black.
			}
			catch
			{
				// do nothing
			}
		}
	}

	private void ColorStartAndEnd()
	{
		startWaypoint.SetTopColor(Color.red); // calling SetTopColor method from WAyPoint script.
		endWaypoint.SetTopColor(Color.blue);
	}

	private void LoadCubes()
	{
		var waypoints = FindObjectsOfType<WayPoint>(); // everything with waypoints script gets called
		foreach (WayPoint waypoint in waypoints)
		{
			var gridPos = waypoint.GetGridPosition();
			if (grid.ContainsKey(gridPos))
			//overlapping blocks?
			{
				Debug.LogWarning("Overlapping block" + waypoint);
			}
			else
			{
				grid.Add(gridPos, waypoint);
				//waypoint.SetTopColor(Color.black); // calling SetTopColor method from WayPoint script.
				// add to dictionary
			}
		}
		//print("Loaded" + grid.Count + "Cubes");
	}
} // end of class
