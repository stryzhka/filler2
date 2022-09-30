using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Damage;
    public float Range;
    public float Force;
    public AudioSource SoundSource;
    public AudioClip Sound;
    public GameObject Explosion;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ExplosionDamage()
    {
    	Collider[] colliders = Physics.OverlapSphere(transform.position, Range);
    	AudioSource.PlayClipAtPoint(Sound, transform.position);
    	foreach (Collider col in colliders)
    	{
    		print (col.gameObject.name);
    		if (col.gameObject.tag == "Creature")
    		{
    			col.gameObject.GetComponent<CreatureBehaviour>().GetDamage(Damage);
    			col.gameObject.GetComponent<Rigidbody>().AddExplosionForce(Force, transform.position, Range);
    		}
            if (col.gameObject.tag == "Boss")
            {
                col.gameObject.GetComponent<BossEyes>().GetDamage(Damage);
                //col.gameObject.GetComponent<Rigidbody>().AddExplosionForce(Force, transform.position, Range);
            }
    	}
    }

    void OnCollisionEnter (Collision col)
    {

    		if (col.gameObject.tag == "Creature")
    		{
    			ExplosionDamage();
    			Instantiate(Explosion, transform.position, Quaternion.identity);
    			Destroy(gameObject);
    		}
            if (col.gameObject.tag == "Boss")
            {
                ExplosionDamage();
                Instantiate(Explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
    }
}
