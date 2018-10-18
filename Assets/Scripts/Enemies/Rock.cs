using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour {
    [SerializeField]
    private float rockHealth = 20f;

    [SerializeField]
    private Vector3 playerPosition;

    [SerializeField]
    private float speed = 3f;

    private Vector2 playerDir;
    private float xDiff;
    private float yDiff;
    private Rigidbody2D rigBody;
    

    void Start()
    {
        rigBody = gameObject.GetComponent<Rigidbody2D>();
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
            rockHealth -= 5f;
        }
    }

    IEnumerator DestroyRock()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
