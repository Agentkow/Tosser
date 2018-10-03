using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

    [SerializeField]
    private TankManager tank;

    [SerializeField]
    private GameObject spawnPoint;

    [SerializeField]
    private Rigidbody2D firedAmmo;

    private float force = 100;

     void Update()
    {
        if (tank.fullAmmo)
        {
            firedAmmo = tank.loadedAmmo.GetComponent<Rigidbody2D>();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (tank.fullAmmo)
        {
            Rigidbody2D instance = Instantiate(firedAmmo, spawnPoint.gameObject.transform.position, spawnPoint.gameObject.transform.rotation);
            instance.velocity = force * this.gameObject.transform.right;

            tank.fullAmmo = false;
        }
    }
}
