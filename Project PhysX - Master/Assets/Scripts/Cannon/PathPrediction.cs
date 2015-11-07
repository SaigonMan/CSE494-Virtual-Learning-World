using UnityEngine;

public class PathPrediction : MonoBehaviour
{
    public LineRenderer sightLine;
    public CannonFire playerFire;
    public GameObject cannonModel; 
    public int segmentCount = 200;
    public float segmentScale = .3F;

    private Collider _hitObject;
    public Collider hitObject { get { return _hitObject; } }

    void FixedUpdate()
    {
        simulatePath();
    }

    void simulatePath()
    {
        Vector3[] segments = new Vector3[segmentCount];
        Vector3 segVelocity = cannonModel.transform.forward * playerFire.force * Time.deltaTime;

        segments[0] = cannonModel.transform.position;
        _hitObject = null;

        for (int i = 1; i < segmentCount; i++)
        {
            float segTime;
            if(segVelocity.sqrMagnitude != 0)
                segTime = segmentScale / segVelocity.magnitude;
            else
                segTime = 0;

            segVelocity = segVelocity + Physics.gravity * segTime;

            //Only path predict for blocks
            RaycastHit hit;
            //Collided With Block
            if (Physics.Raycast(segments[i - 1], segVelocity, out hit, segmentScale) && hit.collider.tag == "Block") 
            {
                _hitObject = hit.collider;

                // Next Position
                segments[i] = segments[i - 1] + segVelocity.normalized * hit.distance;
                // Next Velocity
                segVelocity = segVelocity - Physics.gravity * (segmentScale - hit.distance) / segVelocity.magnitude;
                // Simulates A Bounce (Delete Probably?
                segVelocity = Vector3.Reflect(segVelocity, hit.normal);
            }
            //Travelling in the air
            else
            {
                segments[i] = segments[i - 1] + segVelocity * segTime;
            }
        }

        Color startColor = Color.red;
        Color endColor = startColor;
        startColor.a = 1;
        endColor.a = 0;
        sightLine.SetColors(startColor, endColor);

        sightLine.SetVertexCount(segmentCount);
        for (int i = 0; i < segmentCount; i++)
        {
            sightLine.SetPosition(i, segments[i]);
            sightLine.SetWidth(.3F, .3F);
        }
    }
}