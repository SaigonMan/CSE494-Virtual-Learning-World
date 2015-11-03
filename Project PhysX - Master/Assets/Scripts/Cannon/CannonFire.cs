using UnityEngine;
using System.Collections;

public class CannonFire : MonoBehaviour {

	public GameObject cannonBarrel;
	public ParticleSystem fireParticles;
    public GameObject gamePanel;
	public float force;
    public int size;

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			Fire ();
		}

        force = float.Parse(gamePanel.GetComponent<ChangePhysics>().force);
        size = gamePanel.GetComponent<GameScreenController>().size;
	}

	void Fire()
	{
		GameObject newBall = (GameObject)Instantiate(PrefabController.prefabController.cannonBall,cannonBarrel.transform.position,Quaternion.identity);
        newBall.GetComponent<Rigidbody>().transform.localScale = new Vector3(size,size,size);
		newBall.GetComponent<Rigidbody>().AddForce(cannonBarrel.transform.forward * force);

		//Play particle burst
		fireParticles.Play();
	}
}
