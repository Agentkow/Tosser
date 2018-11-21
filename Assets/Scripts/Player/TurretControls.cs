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

    [SerializeField]
    private AudioSource tankShot;
    
    private float rotateForce = 50f;
    private float minRotate = 80f;
    private float maxRotate = -40f;
    private float rotateZ;
    private float force = 100;
    //private float fireRate = 2;
    //private bool canFire;

    private bool isOnCooldown;
    [SerializeField]
    private float fireCooldownTime = 0.5f;


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

        rotateZ += Time.deltaTime * rotateForce * Input.GetAxis("TurretAim");
        //if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W))
        //{
        //    rotateZ += Time.deltaTime * rotateForce;
        //}

        //if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S))
        //{
        //    rotateZ += Time.deltaTime * -rotateForce;
        //}

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
            if (tank.ammoCount != 0 && !isOnCooldown)
            {
                Rigidbody2D instance = Instantiate(firedAmmo, spawnPoint.gameObject.transform.position, spawnPoint.gameObject.transform.rotation);
                instance.velocity = force * turret.transform.right;
                tankShot.Play();
                tank.fullAmmo = false;
                tank.ammoCount--;
                isOnCooldown = true;
                StartCoroutine(HandleCooldown(fireCooldownTime));
            }
        }
    }

    IEnumerator HandleCooldown(float rate)
    {
        yield return new WaitForSeconds(rate);
        isOnCooldown = false;
    }

    
}
