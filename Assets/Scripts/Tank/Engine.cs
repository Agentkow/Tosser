using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using EZCameraShake;

public class Engine : MonoBehaviour {

    [SerializeField]
    private TankManager tank;
    
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
                CameraShaker.Instance.StartShake(0.1f, 1f, 0.1f);

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
                CameraShaker.Instance.ShakeOnce(3f, 4f, 0.1f, 1f);
                tank.health -= 5;
            }
            Destroy(collision.gameObject);
        }
    }
}
