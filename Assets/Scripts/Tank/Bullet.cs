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
    private TrailRenderer trail;
    private float lifeTime = 10f;
    public float damage = 5f;

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
        Destroy(trail);
        StartCoroutine(DestroyBullet());
    }

    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(blastSound.clip.length);
        Destroy(explosion.gameObject, 0.3f);
        Destroy(gameObject);
    }
    
}
