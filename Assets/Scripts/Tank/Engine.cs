using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Engine : MonoBehaviour {

    [SerializeField]
    private TankManager tank;

    [SerializeField]
    private CameraShake camShake;

    [SerializeField]
    private SwapModes swap;

    private AudioSource oilSound;

    private bool neverDestroyed = true;

    public static event Action FirstFuelDestroyed;

    void Start()
    {
        oilSound = gameObject.GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "GrabObject")
        {
            if (collision.gameObject.name == "Fuel(Clone)")
            {
                tank.fuel += 100;

                if (swap.currentAudio == swap.tankIn)
                {
                    swap.tankIn.Play();
                }
                else if (swap.currentAudio == swap.tankOut)
                {
                    swap.tankOut.Play();
                }

                if (neverDestroyed)
                {
                    if (FirstFuelDestroyed != null)
                    {
                        FirstFuelDestroyed.Invoke();
                    }
                    neverDestroyed = false;
                }

                oilSound.Play();
            }
            else
            {
                camShake.Shake(0.2f, 0.3f);
                tank.health -= 5;
            }
            Destroy(collision.gameObject);
        }
    }
}
