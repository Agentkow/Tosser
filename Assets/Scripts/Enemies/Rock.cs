using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour {
    [SerializeField]
    private float rockHealth = 20f;

    void Update()
    {


        if (rockHealth <= 0)
        {
            StartCoroutine(DestroyRock());
            this.gameObject.SetActive(false);
        }
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
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
