using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TurretControls : MonoBehaviour {

    [SerializeField]
    private GameObject turret;

    [SerializeField]
    private TankManager tank;

    [SerializeField]
    private GameObject spawnPoint;

    [SerializeField]
    private Rigidbody2D firedAmmo;
    
    private float rotateForce = 50f;
    private float minRotate = 80f;
    private float maxRotate = -40f;
    private float rotateZ;

    private float force = 100;
    

    void Update()
    {

        Fire();

        Rotational();

    }

    private void Rotational()
    {

        if (rotateZ > minRotate)
        {
            rotateZ = minRotate;
        }

        if (rotateZ < maxRotate)
        {
            rotateZ = maxRotate;
        }

        if (Input.GetKey(KeyCode.A))
        {
            rotateZ += Time.deltaTime * rotateForce;
        }

        if (Input.GetKey(KeyCode.D))
        {
            rotateZ += Time.deltaTime * -rotateForce;
        }

        rotateZ = Mathf.Clamp(rotateZ, maxRotate, minRotate);
        turret.transform.rotation = Quaternion.Euler(0, 0, rotateZ);
        
    }

    private void Fire()
    {
        if (tank.ammoCount!=0)
        {
            firedAmmo = tank.loadedAmmo.GetComponent<Rigidbody2D>();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (tank.ammoCount != 0)
            {
                Rigidbody2D instance = Instantiate(firedAmmo, spawnPoint.gameObject.transform.position, spawnPoint.gameObject.transform.rotation);
                instance.velocity = force * turret.transform.right;
                tank.fullAmmo = false;
                tank.ammoCount--;
            }
        }
    }
}
