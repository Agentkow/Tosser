using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reload : MonoBehaviour {

    [SerializeField]
    private TankManager tank;

    [SerializeField]
    private GameObject ammotype1;

    private AudioSource ammoSound;

    void Start()
    {
        ammoSound = gameObject.GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "GrabObject")
        {
            if (!tank.fullAmmo)
            {
                if (tank.ammoCount!= tank.maxAmmo)
                {
                    if (collision.gameObject.name == "Ammo(Clone)")
                    {
                        tank.ammoCount += 5;
                        tank.loadedAmmo = ammotype1;
                        ammoSound.Play();
                    }
                    Destroy(collision.gameObject);
                }
                else
                {
                    tank.ammoCount = tank.maxAmmo;
                    tank.fullAmmo = true;
                }
                
            }
        }
    }
}
