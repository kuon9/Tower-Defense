using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

	[SerializeField] Collider collisionMesh;


	// Use this for initialization
	void Start () {
	
	}
/// OnParticleCollision is called when a particle hits a collider.
/// </summary>
/// <param name="other">The GameObject hit by the particle.</param>
private	void OnParticleCollision(GameObject other)
	{
		print(" I'm hit yee");
	}
} // end of class.
