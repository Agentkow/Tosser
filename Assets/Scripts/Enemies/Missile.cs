using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {

    [SerializeField]
    private TankManager tank;

    [SerializeField]
    private Vector3 playerPosition;

    [SerializeField]
    private ParticleSystem explosion;
    private Vector2 playerDir;
    private float xDiff;
    private float yDiff;
    private float speed = 10000f;
    private float missileHealth = 10f;

    private Rigidbody2D rigBody;

    void Start()
    {
        rigBody = GetComponent<Rigidbody2D>();
        explosion.Stop();
    }

    void Update()
    {
        RotatingMissile();
        TankTargeting();

        if (missileHealth <= 0)
        {
            explosion.transform.parent = null;
            explosion.Play();
            Destroy(explosion.gameObject, 0.3f);
            Destroy(gameObject);
        }
    }

    private void RotatingMissile()
    {
        Vector2 direction = GameObject.Find("Tank").transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
    }

    private void TankTargeting()
    {
        playerPosition = GameObject.Find("Tank").transform.position;
        xDiff = playerPosition.x - transform.position.x;
        yDiff = playerPosition.y - transform.position.y;
        playerDir = new Vector2(xDiff, yDiff);
        rigBody.AddForce(playerDir.normalized * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            missileHealth -= 5f;
        }
    }
    
}
