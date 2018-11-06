using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour {

    [SerializeField]
    private TankManager tank;

    [SerializeField]
    private CameraShake camShake;

    [SerializeField]
    private SwapModes swap;

    private AudioSource oilSound;

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

                oilSound.Play();
            }
            else
            {
                camShake.Shake(0.3f, 0.4f);
                tank.health -= 5;
            }
            Destroy(collision.gameObject);
        }
    }
}
