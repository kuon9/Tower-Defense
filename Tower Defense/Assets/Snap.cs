using System.Collections;
using System.Collections.Generic;
using UnityEngine;

	[ExecuteInEditMode]
public class Snap : MonoBehaviour {

	[SerializeField] [Range(1f, 20f)] float gridSize = 10f; // range allows a dragging function from 1 to 20.
	// you can also manually punch in the number into the float rather than use range also.

	void Update () {
		Vector3 snapPosition;
		snapPosition.x = Mathf.RoundToInt (transform.position.x / gridSize) * gridSize; // transform.position.x is the x position of cube.
		snapPosition.z = Mathf.RoundToInt (transform.position.z / gridSize) * gridSize;

		transform.position = new Vector3(snapPosition.x, 0 , snapPosition.z);

	}
} // end of class
