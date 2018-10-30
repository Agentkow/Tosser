using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour {
    [SerializeField]
    private float rockHealth = 20f;
    
    [SerializeField]
    private float speed = 200f;
    
    private Rigidbody2D rigBody;

    private AudioSource blastSound;
    
    void Start()
    {
        rigBody = gameObject.GetComponent<Rigidbody2D>();
        blastSound = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        TankTargeting();

        if (rockHealth <= 0)
        {
            StartCoroutine(DestroyRock());
            this.gameObject.SetActive(false);
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
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
