using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    [SerializeField]
    private GameObject throwable;

    [SerializeField]
    private GameObject spawnPoint;

    [SerializeField]
    private Sprite buttonPressed;

    [SerializeField]
    private Sprite buttonReleased;

    [SerializeField]
    private AudioSource dropSound;

    private SpriteRenderer currentSprite;
    private bool hasSpawned = false;

    public bool pressed;

    void Start()
    {
        currentSprite = gameObject.GetComponent < SpriteRenderer>();
    }

    // Update is called once per frame
    void Update () {
        
        if (pressed)
        {
            if (!hasSpawned)
            {
                Instantiate(throwable, spawnPoint.gameObject.transform.position - new Vector3(0,0.3f,0), spawnPoint.gameObject.transform.rotation);
                dropSound.Play();
                hasSpawned = true;
            }
        }
        else
        {
            hasSpawned = false;
        }
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        pressed = true;
        currentSprite.sprite = buttonPressed;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        pressed = false;
        currentSprite.sprite = buttonReleased;
    }


}
