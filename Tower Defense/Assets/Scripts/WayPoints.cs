using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour {

	Vector2Int gridPos;
	
	const int gridSize = 10;

	public int GetGridSize()
	{
		return gridSize;
	}

	public Vector2 GetGridPosition()
	{
		return new Vector2Int(
		  Mathf.RoundToInt (transform.position.x / gridSize) * gridSize, // transform.position.x is the x position of cube.
		  Mathf.RoundToInt (transform.position.z / gridSize) * gridSize
		);	
	}
} // end of class
