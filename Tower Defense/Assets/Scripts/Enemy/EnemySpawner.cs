using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {

	[Range(0.1f,120f)][SerializeField] float timeBetweenSpawn = 2f;
	[SerializeField] EnemyMovement enemyPrefab;
	[SerializeField] EnemyMovement BossPrefab;
	[SerializeField] Transform enemyParentTransform;
	[SerializeField] AudioClip spawnEnemySFX;
	


	// Use this for initialization
	void Start ()
	{
		StartCoroutine(SpawnEnemies());
		
	}
	
	IEnumerator SpawnEnemies()
	{
		while(true) //  forever
		{
			
			GetComponent<AudioSource>().PlayOneShot(spawnEnemySFX);
			var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
			newEnemy.transform.parent = enemyParentTransform;
			yield return new WaitForSeconds (timeBetweenSpawn);
		
		}
	}

		


} // end of class

