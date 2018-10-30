using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Siren : MonoBehaviour {

    private SpriteRenderer sirenSprite;

    [SerializeField]
    private GameObject lighting;

    private AudioSource sirenSound;

	void Start () {
        sirenSprite = gameObject.GetComponent<SpriteRenderer>();
        sirenSprite.color = Color.grey;
        sirenSound = gameObject.GetComponent<AudioSource>();
	}

    void FixedUpdate()
    {
        if (GameObject.FindGameObjectsWithTag("Hostile").Length <= 0)
        {
            sirenSprite.color = Color.grey;
            lighting.gameObject.SetActive(false);
            sirenSound.Stop();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hostile")
        {
            sirenSprite.color = Color.red;
            lighting.gameObject.SetActive(true);
            sirenSound.Play();
        }
    }
}
