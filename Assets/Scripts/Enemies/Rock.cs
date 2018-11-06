using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour {
    [SerializeField]
    private float rockHealth = 20f;
    
    [SerializeField]
    private float speed = 200f;
    
    private Rigidbody2D rigBody;
    private SpriteRenderer rockSprite;
    private CircleCollider2D rockCollider;
    private AudioSource blastSound;
    
    void Start()
    {
        rigBody = gameObject.GetComponent<Rigidbody2D>();
        blastSound = gameObject.GetComponent<AudioSource>();
        rockSprite = gameObject.GetComponent<SpriteRenderer>();
        rockCollider = gameObject.GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        TankTargeting();

        if (rockHealth <= 0)
        {
            StartCoroutine(DestroyRock());
            rockSprite.enabled = false;
            rockCollider.enabled = false;
            

        }
    }

    private void TankTargeting()
    {
        rigBody.AddForce(Vector2.left*speed,ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            blastSound.Play();
            rockHealth -= 5f;
        }
    }

    IEnumerator DestroyRock()
    {
        yield return new WaitForSeconds(blastSound.clip.length);
        Destroy(gameObject);
    }
}
