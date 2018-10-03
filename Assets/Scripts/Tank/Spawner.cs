using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    [SerializeField]
    private GameObject throwable;

    [SerializeField]
    private GameObject spawnPoint;

    private bool hasSpawned = false;

    public bool pressed;

    

    // Update is called once per frame
    void Update () {
        
        if (pressed)
        {
            if (!hasSpawned)
            {
                Instantiate(throwable, spawnPoint.gameObject.transform.position, spawnPoint.gameObject.transform.rotation);
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
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        pressed = false;
    }


}
