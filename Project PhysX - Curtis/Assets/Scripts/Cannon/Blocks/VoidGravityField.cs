using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VoidGravityField : MonoBehaviour {
	
	public LayerMask cannonballMask;
	
	public float gravitationalForce;

	private float gravitationalRadius;	//Gets set to the sixe of the trigger zone's radius

	void Start(){
		gravitationalRadius = GetComponent<SphereCollider>().radius;	//GravitaionalRadius set up here
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.CompareTag("Cannon Ball")){
			StopAllCoroutines();	//Just incase so we dont start calling it multiple times
			StartCoroutine("GravityField");
		}
	}

	public IEnumerator GravityField(){
		int cannonBallCount = 0;
		do
		{
			cannonBallCount = 0;	//Reset count

			foreach(Collider cannonBall in Physics.OverlapSphere(transform.position,gravitationalRadius,cannonballMask))
			{
				cannonBallCount++;	//Count as we read in
				cannonBall.transform.GetComponent<Rigidbody>().AddForce(gravitationalForce * (transform.position - cannonBall.transform.position).normalized);
			}
			yield return new WaitForEndOfFrame();
		}while(cannonBallCount != 0);
	}
}
