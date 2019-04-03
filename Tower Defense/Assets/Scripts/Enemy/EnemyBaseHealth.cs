using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseHealth : MonoBehaviour {

	[SerializeField] int health = 10;
	[SerializeField] int healthdamage = 1;



	private void OnTriggerEnter (Collider other)
	{
		health = health - healthdamage;
	}

}
