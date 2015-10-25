using UnityEngine;
using System.Collections;

public class CannonMotion : MonoBehaviour {

	public Transform cannonBase;
	public Transform cannonBarrel;
	public float turnSpeed;
	public float pitchSpeed;
	float startTurnSpeed;
	float startPitchSpeed;
	float maxSpeedFactor = 4;
	float increaseFactor = .025f;

	public bool atUpperBound = false;
	public bool atLowerBound = false;

	public LayerMask boundMask;

	void Start(){
		startTurnSpeed = turnSpeed;
		startPitchSpeed = pitchSpeed;
	}

	//Cannon base rotation and cannon barrel pitch adjustments
	//Includes ramp-up speed feature for quick motion as well as control for precise aiming
	void Update () {
		//Raycast check for max/min
		//Debug.DrawRay(cannonBarrel.position,cannonBarrel.forward,Color.red,.2f);
		RaycastHit hit;
		if(Physics.Raycast(cannonBarrel.position,cannonBarrel.forward,out hit, 2f, boundMask))
		{
			if(hit.collider.GetComponent<CannonMotionStopper>().stopperType == StopperType.Upper)
			{
				atUpperBound = true;
			}
			//Lower
			else
			{
				atLowerBound = true;
			}
		}
		else
		{
			atUpperBound = false;
			atLowerBound = false;
		}

		//Check left/right motion
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			//Turn left
			cannonBase.Rotate(Vector3.up,Time.deltaTime * -turnSpeed);
			//If not over speed limit, increase speed
			if(turnSpeed < startTurnSpeed * maxSpeedFactor)
			{
				turnSpeed+= turnSpeed * increaseFactor;
			}
		}
		else if (Input.GetKey(KeyCode.RightArrow))
		{
			//Turn right
			cannonBase.Rotate(Vector3.up,Time.deltaTime * turnSpeed);
			//If not over speed limit, increase speed
			if(turnSpeed < startTurnSpeed * maxSpeedFactor)
			{
				turnSpeed+= turnSpeed * increaseFactor;
			}
		}
		else if(turnSpeed != startTurnSpeed)
		{
			//Reset speed to original
			turnSpeed = startTurnSpeed;
		}

		//Check up/down motion
		if(Input.GetKey(KeyCode.UpArrow) && !atUpperBound)//cannonBarrel.eulerAngles.z < 180f)
		{
			//pitch up
			cannonBarrel.Rotate(Vector3.right, Time.deltaTime * -pitchSpeed);
			//If not over speed limit, increase speed
			if(pitchSpeed < startPitchSpeed * maxSpeedFactor)
			{
				pitchSpeed+= pitchSpeed * increaseFactor;
			}
		}
		else if (Input.GetKey(KeyCode.DownArrow) && !atLowerBound)//cannonBarrel.eulerAngles.x > 180f)
		{
			//if(cannonBarrel.localRotation.eulerAngles.x)
			//pitch down
			cannonBarrel.Rotate(Vector3.right, Time.deltaTime * pitchSpeed);
			//If not over speed limit, increase speed
			if(pitchSpeed < startPitchSpeed * maxSpeedFactor)
			{
				pitchSpeed+= pitchSpeed * increaseFactor;
			}
		}
		else if(pitchSpeed != startPitchSpeed)
		{
			//Reset speed to original
			pitchSpeed = startPitchSpeed;
		}
	}
}
