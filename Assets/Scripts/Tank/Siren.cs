using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Siren : MonoBehaviour {

    private SpriteRenderer sirenSprite;

	void Start () {
        sirenSprite = gameObject.GetComponent<SpriteRenderer>();
        sirenSprite.color = Color.black;
	}

    void FixedUpdate()
    {
        if (GameObject.FindGameObjectsWithTag("Hostile").Length <= 0)
        {
            sirenSprite.color = Color.black;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hostile")
        {
            sirenSprite.color = Color.red;
        }
    }
}
