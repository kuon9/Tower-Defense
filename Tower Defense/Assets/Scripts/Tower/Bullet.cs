using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {


	private Transform Target;

	[SerializeField] float speed = 70f;
	[SerializeField] ParticleSystem bulletImpact;

	public void Seek(Transform target)
	{
		Target = target;
	}
	
	// Update is called once per frame
	void Update () {
		if(Target == null)
		{
			Destroy(gameObject); // we put return; because destroy sometime takes a bit before it happens
			return;
		}

		Vector3 dir = Target.position - transform.position;
		float distanceThisFrame = speed * Time.deltaTime;

		if( dir.magnitude <= distanceThisFrame)
		//dir.magnitude = direction vector is less than distancethisframe
		{
			HitTarget();
			return;
		}
		transform.Translate(dir.normalized * distanceThisFrame, Space.World);
		// study transform.Translate on UNITY API.

	}
	void HitTarget()
	{
		ParticleSystem Bullet =(ParticleSystem) Instantiate(bulletImpact,transform.position, transform.rotation);
		Destroy(Bullet, 2f);
		Destroy(gameObject);
	}

}
