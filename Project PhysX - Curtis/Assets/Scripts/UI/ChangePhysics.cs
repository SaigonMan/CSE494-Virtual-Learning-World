using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangePhysics : MonoBehaviour {

    public GameObject forceTextPlaceholder;
    public GameObject forceText;
    public GameObject cannon;
    public Text myText;
    public string force;
    public float testForce;
	// Use this for initialization
	void Start () {

        force = cannon.GetComponent<CannonFire>().force.ToString();
        testForce = float.Parse(force);
        myText = forceTextPlaceholder.GetComponent<Text>();
        myText.text = force;
	}
	
	// Update is called once per frame
	public void checkValid () {
        myText = forceText.GetComponent<Text>();
        if (float.TryParse(myText.text, out testForce))
            force = myText.text;
        else
            myText.text = force;
	}
}
