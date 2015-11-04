using UnityEngine;
using System.Collections;

//Keeps loaded prefabs in singleton for ease of access
public class PrefabController : MonoBehaviour {

	//Singleton
	public static PrefabController prefabController;

	//Prefab Types
	public GameObject cannonBall;
    public GameObject explosion;

	void Awake(){
		//Make singleton
		prefabController = this;
	}
}
