using System;
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
    private Sprite chuteOpen;
    [SerializeField]
    private Sprite chuteClose;

    [SerializeField]
    private AudioSource dropSound;

    [SerializeField]
    private SpriteRenderer chuteSprite;
    
    private SpriteRenderer currentSprite;
    private bool hasSpawned = false;
    private bool neverSpawnedFuel = true;
    private bool neverSpawnedAmmo = true;

    public bool pressed;

    public static event Action FirstFuelSpawned;
    public static event Action FirstAmmoSpawned;

    void Start()
    {
        currentSprite = gameObject.GetComponent < SpriteRenderer>();
    }

    // Update is called once per frame
    void Update ()
    {
        SpawnThrowableItem();
    }

    private void SpawnThrowableItem()
    {
        if (pressed)
        {
            if (!hasSpawned)
            {
                Instantiate(throwable, spawnPoint.gameObject.transform.position - new Vector3(0, 0.3f, 0), spawnPoint.gameObject.transform.rotation);
                dropSound.Play();

                FirstFuelSpawn();

                if (neverSpawnedAmmo)
                {
                    if (FirstAmmoSpawned!= null && throwable.name == "Ammo")
                    {
                        FirstAmmoSpawned.Invoke();
                    }
                    neverSpawnedAmmo = false;
                }

                hasSpawned = true;
            }
        }
        else
        {
            hasSpawned = false;
        }
    }

    private void FirstFuelSpawn()
    {
        if (neverSpawnedFuel)
        {
            if (FirstFuelSpawned != null && throwable.name == "Fuel")
            {
                FirstFuelSpawned.Invoke();
            }
            neverSpawnedFuel = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        pressed = true;
        currentSprite.sprite = buttonPressed;
        chuteSprite.sprite = chuteOpen;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        pressed = false;
        currentSprite.sprite = buttonReleased;
        chuteSprite.sprite = chuteClose;
    }


}
