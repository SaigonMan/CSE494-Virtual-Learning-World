using UnityEngine;
using System.Collections;

public class BoomExplosion : MonoBehaviour {

    public float explosionForce;

    //Starting health of the boom block
    public float health;

    bool blown = false;

    void OnCollisionEnter(Collision col)
    {
        
        //Calculate value of hit
        ContactPoint contact = col.contacts[0];
        float val = Vector3.Distance(transform.position, transform.position + col.relativeVelocity);

        //Check for actual big collision, not some sissy tap for the blocks settling in
        if (val > 1)
        {
            health -= val;
        }

        //Explode if necessary
        if (health <= 0 && !blown)
        {
            blown = true;
            Blowup();
        }
    }

    //Blow it up when health is out
    //Can be called whenever desired as well
    public void Blowup()
    {
        GameObject explosion = (GameObject)Instantiate(PrefabController.prefabController.explosion,transform.position,Quaternion.identity);
        explosion.GetComponent<Explosion>().explosionForce = explosionForce;

        //Kill yourself
        Destroy(this.gameObject);
    }
}
