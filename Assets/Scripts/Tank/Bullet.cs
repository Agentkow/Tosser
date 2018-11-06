using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField]
    private ParticleSystem explosion;

    [SerializeField]
    private AudioSource blastSound;

    [SerializeField]
    private SpriteRenderer render;

    [SerializeField]
    private CapsuleCollider2D colliderBullet;

    [SerializeField]
    private TrailRenderer trail;
    private float lifeTime = 10f;
    public float damage = 5f;
    public bool destroyed = false;

    void Start()
    {
        explosion.Stop();
        render = gameObject.GetComponent<SpriteRenderer>();
         
        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        explosion.transform.parent = null;
        explosion.Play();
        blastSound.Play();
        render.enabled = false;
        colliderBullet.enabled = false;
        Destroy(trail);
        Destroy(gameObject, blastSound.clip.length);
        Destroy(explosion.gameObject, blastSound.clip.length);
        
    }
    
}
