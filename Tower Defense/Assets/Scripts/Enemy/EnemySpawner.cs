﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	[Range(0.1f,120f)][SerializeField] float timeBetweenSpawn = 2f;
	[SerializeField] EnemyMovement enemyPrefab;
	[SerializeField] Transform enemyParentTransform;
 
	// Use this for initialization
	void Start () {
		StartCoroutine(SpawnEnemies());
	}
	
	IEnumerator SpawnEnemies()
	{
		while(true) //  forever
		{
			var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
			newEnemy.transform.parent = enemyParentTransform;
			yield return new WaitForSeconds (timeBetweenSpawn);
		}
	}
} // end of class

