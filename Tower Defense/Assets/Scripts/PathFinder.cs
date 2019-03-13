using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour {

	// start from bottom and go up when fixing unity errors yee.

	[SerializeField] WayPoint  startWaypoint, endWaypoint; // two gameobject tabs in inspector, this allows me to drag which cube i want to be start and end.
	Dictionary<Vector2Int, WayPoint> grid = new Dictionary<Vector2Int, WayPoint>();
	Queue<WayPoint> queue = new Queue<WayPoint>();
	bool isRunning = true; // to make private
	WayPoint searchCenter; // the current searchCenter
    List<WayPoint> path = new List<WayPoint>(); // todo make private



	Vector2Int[] directions = 
	{
		Vector2Int.up,
		Vector2Int.down,
		Vector2Int.right,
		Vector2Int.left
	}; 

	public List<WayPoint> GetPath()
	{
		LoadCubes();
		ColorStartAndEnd();
		BreadthFirstSearch();
		CreatePath();
		return path;
	}

	private void CreatePath()
	{
		path.Add(endWaypoint);

		WayPoint previous = endWaypoint.exploredFrom;
		while (previous != startWaypoint)
		{
			path.Add(previous);
			//add intermediate waypoints
			previous = previous.exploredFrom;
		}
			path.Add(startWaypoint);
			// add start waypoint
			path.Reverse();
			//reverse the list
	}

	private void BreadthFirstSearch() // simple and efficient most of the time. One of the three search formulas
	{
		queue.Enqueue(startWaypoint); // adds to end of the queue.

		while(queue.Count > 0 && isRunning)
		{
		    searchCenter = 	queue.Dequeue(); // return to front of the queue.
			HaltIfEndFound();
			ExploreNeighbours();
			searchCenter.isExplored = true;
		}
		print("Finished BreadthFirstSearching?");
	}

	private void HaltIfEndFound()
	{
		 if(searchCenter == endWaypoint)
		 {
			print("Searching from end node, therefore stopping");
		 	isRunning = false;
		 }
	}

	private void ExploreNeighbours ()
	{	
		if(!isRunning) { return; }
		
		foreach(Vector2Int direction in directions)
		{
			Vector2Int neighborCoordinates = searchCenter.GetGridPosition() + direction;
			if(grid.ContainsKey(neighborCoordinates))
			{
				QueueNewNeighbours(neighborCoordinates);
			}

		}
	}

	private void QueueNewNeighbours(Vector2Int neighborCoordinates)
	{		
		WayPoint neighbour = grid[neighborCoordinates]; // WayPoint becomes neighbour and it equals grid[neighborcoordinates] yeee.
		if(neighbour.isExplored || queue.Contains(neighbour)) // don't queue 0,0 because we're marking it as explored.
		{
			// do nothing
		}
		else
		{
		neighbour.SetTopColor(Color.black);// sets the area we're exploring into black.
		queue.Enqueue(neighbour);
		print("Queueing" + neighbour);
		}
	}



	private void ColorStartAndEnd()
	{
		// todo consider moving out.
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
