using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour {

	Vector2Int gridPos;
	
	const int gridSize = 10;

	public int GetGridSize()
	{
		return gridSize;
	}

	public Vector2Int GetGridPosition()
	{
		return new Vector2Int(
		  Mathf.RoundToInt (transform.position.x / gridSize) * gridSize, // transform.position.x is the x position of cube.
		  Mathf.RoundToInt (transform.position.z / gridSize) * gridSize
		);	
	}

	public void SetTopColor(Color color) // this is a method. (Color = type, color is variable)
	{
	   MeshRenderer topMeshRenderer= transform.Find("Top").GetComponent<MeshRenderer>();
	   topMeshRenderer.material.color = color; // color = albedo in inspector tab.
	} 
} // end of class
