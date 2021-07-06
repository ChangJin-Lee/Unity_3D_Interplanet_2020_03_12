using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csMissile : MonoBehaviour
{
    public GameObject explosionParticlesPrefab;

    ParticleSystem testParticle = null;

    // Start is called before the first frame update
    void Start()
    {
        testParticle = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        ShootMissile();
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "ASTEROID")
        {
            if (explosionParticlesPrefab)
            {
            GameObject explosion = (GameObject)Instantiate(explosionParticlesPrefab, other.transform.position, other.transform.rotation);

            Destroy(explosion, explosion.GetComponent<ParticleSystem>().main.startLifetime.constant);

            AudioSource.PlayClipAtPoint(Resources.Load("explosion") as AudioClip, transform.position);

            }
            Destroy(other);
        }

    }
    void ShootMissile()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (testParticle)
            {
                if(testParticle.isPlaying == true)
                {
                    testParticle.Stop();
                    testParticle.Clear();
                }
                else
                {
                    testParticle.Play();
                }
            }
        } 
    }
}
