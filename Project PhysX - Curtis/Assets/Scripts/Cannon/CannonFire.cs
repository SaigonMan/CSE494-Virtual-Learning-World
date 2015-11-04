using UnityEngine;
using System.Collections;

public class CannonFire : MonoBehaviour {

	public GameObject cannonBarrel;
	public ParticleSystem fireParticles;
    public GameObject gamePanel;
	public float force;
    public int size;

	GameObject cannonBall;

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			if(cannonBall == null){
				//Create if not created
				cannonBall = (GameObject)Instantiate(PrefabController.prefabController.cannonBall,cannonBarrel.transform.position,Quaternion.identity);
			}else{
				//Reset and kill motion
				cannonBall.transform.position = cannonBarrel.transform.position;
				cannonBall.GetComponent<Rigidbody>().velocity = Vector3.zero;
				cannonBall.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			}
            cannonBall.GetComponent<Rigidbody>().transform.localScale = new Vector3(size, size, size);
			Fire ();
		}

        force = float.Parse(gamePanel.GetComponent<ChangePhysics>().force);
        size = gamePanel.GetComponent<GameScreenController>().size;
	}

	void Fire()
	{
		cannonBall.GetComponent<Rigidbody>().AddForce(cannonBarrel.transform.forward * force);
        

		//Play particle burst
		fireParticles.Play();
	}
}
