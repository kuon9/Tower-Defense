using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {


[SerializeField] Transform Unit; // Which tower will do targeting pretty much. 
[SerializeField] Transform targetEnemy; //you gonna put in the enemy in this slot so our towers look at them..\


	// Update is called once per frame
	void Update () {
		Unit.LookAt(targetEnemy); // tower will look at enemy yee.
	}
} // end of class
