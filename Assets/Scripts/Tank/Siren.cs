using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Siren : MonoBehaviour {

    private SpriteRenderer sirenSprite;

    [SerializeField]
    private GameObject lighting;

	void Start () {
        sirenSprite = gameObject.GetComponent<SpriteRenderer>();
        sirenSprite.color = Color.grey;
	}

    void FixedUpdate()
    {
        if (GameObject.FindGameObjectsWithTag("Hostile").Length <= 0)
        {
            sirenSprite.color = Color.grey;
            lighting.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hostile")
        {
            sirenSprite.color = Color.red;
            lighting.gameObject.SetActive(true);
        }
    }
}
