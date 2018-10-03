using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    [SerializeField]
    private ParticleSystem explosion;
    private float lifeTime = 5f;
    public float damage = 5f;
    void Start()
    {
        explosion.Stop();
        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        explosion.transform.parent = null;
        explosion.Play();
        Destroy(explosion.gameObject, 0.3f);
        Destroy(gameObject);
    }
    
}
