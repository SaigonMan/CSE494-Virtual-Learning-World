using UnityEngine;
using System.Collections;

public class LevelSelect : MonoBehaviour {

	// Use this for initialization
	public void LevelLoad(string levelName)
    {
        Application.LoadLevel(levelName);
    }
}
