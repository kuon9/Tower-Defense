using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCamera : MonoBehaviour {

	public GameObject Position1;
	public GameObject Position2;

	private bool reached_Position1;
	private bool reached_Position2 = true;
    private bool canClick;
	// private bool backToMainMenu;


	// EASIER WAY
	private List<GameObject> positions = new List<GameObject>();
	// EASIER WAY

	void Awake() {
		positions.Add (Position1);
	}

	void Update () {
//		MoveToPosition1 ();
//		MoveToCharacterSelectMenu ();
//
//		MoveBackToMainMenu ();

		MoveToPosition ();
	}

	void MoveToPosition() {
		if (positions.Count > 0) {

			transform.position = Vector3.Lerp (transform.position, 
				positions[0].transform.position, 1f * Time.deltaTime);

			transform.rotation = Quaternion.Lerp (transform.rotation,
				positions[0].transform.rotation, 1f * Time.deltaTime);
		}
	}

	public void ChangePosition(int index) {
		positions.RemoveAt (0);

		if (index == 0) {
			positions.Add (Position1);
		} else {
			positions.Add (Position2);
		}
	}

	void MoveToPosition1() {
		if (!reached_Position1) {
			if (Vector3.Distance (transform.position, Position1.transform.position) < 0.2f) {
				reached_Position1 = true;
				canClick = true;
			}
		}

		if (!reached_Position1) {
			transform.position = Vector3.Lerp (transform.position, Position1.transform.position,
				1f * Time.deltaTime);
			transform.rotation = Quaternion.Lerp (transform.rotation, Position1.transform.rotation,
				1f * Time.deltaTime);
		}
	}

	void MoveToCharacterSelectMenu() {
		if (!reached_Position2) {
			transform.position = Vector3.Lerp (transform.position, 
				Position2.transform.position,
				1f * Time.deltaTime);
			
			transform.rotation = Quaternion.Lerp (transform.rotation, 
				Position2.transform.rotation,
				1f * Time.deltaTime);
		}

		if (!reached_Position2) {
			if (Vector3.Distance (transform.position, Position2.transform.position) < 0.2f) {
				reached_Position2 = true;
				canClick = true;
			}
		}
	}
} // end of class

