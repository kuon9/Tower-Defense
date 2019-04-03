using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {

	[SerializeField] int towerLimit = 5;
	[SerializeField] Tower towerPrefab;
	[SerializeField] Transform towerParentTransform;

	Queue<Tower> towerQueue = new Queue<Tower>(); // <-- it's a method because we're constructing an queue of towers.
	// create an empty queue of towers

	public void AddTower(WayPoint baseWaypoint)
	{
		int numTowers = towerQueue.Count;
	
		if(numTowers < towerLimit)
		{
			InstantiateNewTower(baseWaypoint);
		}
		else
		{	
			MoveExistingTower(baseWaypoint);
		}	
	}


	private void InstantiateNewTower(WayPoint baseWaypoint)
	{
		var newTower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity); // spawns new tower at where your mouse cursor is.
		newTower.transform.parent = towerParentTransform;
		// makes the towers gameobject spawn under world parent.
		baseWaypoint.isAvailable = false; // Instantiate is always ( prefab, transform.position or even transform positon + forward, then finally quaternion.identity.)

		newTower.baseWaypoint = baseWaypoint;
		baseWaypoint.isAvailable = false;
		// set the baseWaypoints.

		towerQueue.Enqueue(newTower); // enqueue is add to end of queue "EN"QUEUE.
		// put new tower on the queue.

	}

	private void MoveExistingTower(WayPoint newbaseWaypoint)
	{
		var oldTower = towerQueue.Dequeue();
		// take bottom tower of queue.

		oldTower.baseWaypoint.isAvailable = true;
		newbaseWaypoint.isAvailable = false;		
		// set the placeable flags.

		oldTower.baseWaypoint = newbaseWaypoint;
		oldTower.transform.position = newbaseWaypoint.transform.position;
		//set the baseWaypoints.

		towerQueue.Enqueue(oldTower);
		// put the old tower on top of the queue.
	}


} // end of class
