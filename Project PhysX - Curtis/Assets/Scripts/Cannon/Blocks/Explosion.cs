using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

    public LayerMask objectsMask;

    public float explosionForce;
    public float explosionRadius;

	void Start () {
        GetComponent<ParticleSystem>().Play();

        foreach (Collider obj in Physics.OverlapSphere(transform.position, explosionRadius, objectsMask))
        {
            obj.transform.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, explosionRadius);
        }

        StartCoroutine("GetPlaying");
	}

    IEnumerator GetPlaying()
    {
        while (GetComponent<ParticleSystem>().isPlaying)
        {
            yield return new WaitForEndOfFrame();
        }

        //Kill yourself
        Destroy(this.gameObject);
        yield return null;
    }
}
