using UnityEngine;
using System.Collections;

public class CannonFire : MonoBehaviour {

	public GameObject cannonBarrel;
	public ParticleSystem fireParticles;

	public float force;

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			Fire ();
		}
	}

	void Fire()
	{
		GameObject newBall = (GameObject)Instantiate(PrefabController.prefabController.cannonBall,cannonBarrel.transform.position,Quaternion.identity);
		newBall.GetComponent<Rigidbody>().AddForce(cannonBarrel.transform.forward * force);

		//Play particle burst
		fireParticles.Play();
	}
}
