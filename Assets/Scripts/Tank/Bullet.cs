using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField]
    private ParticleSystem explosion;

    private AudioSource blastSound;
    private float lifeTime = 5f;
    public float damage = 5f;

    void Start()
    {
        explosion.Stop();
        blastSound = gameObject.GetComponent<AudioSource>();
        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        explosion.transform.parent = null;
        explosion.Play();
        blastSound.Play();
        Destroy(explosion.gameObject, 0.3f);
        gameObject.SetActive(false);
    }

    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(blastSound.clip.length);
        Destroy(gameObject);
    }
    
}
