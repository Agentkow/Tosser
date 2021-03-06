﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using EZCameraShake;
using UnityEngine.SceneManagement;

public class SwapModes : MonoBehaviour {

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private Camera mainCam;

    [SerializeField]
    private TankManager tank;

    [SerializeField]
    private bool inTank = false;

    [SerializeField]
    private Image ammoDisplay;

    [SerializeField]
    private Text ammoText;

    [SerializeField]
    private Slider progressBar;

    [SerializeField]
    public AudioSource tankIn;

    [SerializeField]
    public AudioSource tankOut;

    [SerializeField]
    private SpriteRenderer tankBody;

    private TurretControls turrets;
    private GrabAndThrow grabbing;
    private PlayerMovement playMove;
    public AudioSource currentAudio;
    private Rigidbody2D playerRigBody;
    
    public bool collided = false;
    private bool haventTouched = true;

    [SerializeField]
    private Image fuelLight;
    
    [SerializeField]
    private float timer = 1f;

    private Scene levelScene;
    public static event Action FirstControlContact;
    
    // Use this for initialization
    void Start () {
        fuelLight.enabled = false;
        ammoDisplay.enabled = false;
        ammoText.enabled = false;
        levelScene = SceneManager.GetActiveScene();
        progressBar.gameObject.SetActive(false);
        turrets = player.GetComponent<TurretControls>();
        grabbing = player.GetComponent<GrabAndThrow>();
        playMove = player.GetComponent<PlayerMovement>();
        playerRigBody = player.GetComponent<Rigidbody2D>();
        currentAudio = tankIn;
        tankBody.enabled = false;
        if (levelScene.name !="Tutorial")
        {
            CameraShaker.Instance.StartShake(0.1f, 1f, 0.1f);
        }
        tankIn.Play();
    }

    void Update()
    {
        SwapControls();
        

        progressBar.value = tank.progressInfo.value;
    }

    void FixedUpdate()
    {
        TankFuelLightColor();

        if (tank.fuel <=0)
        {
            tankOut.Stop();
            tankIn.Stop();
        }

        ammoText.text = tank.ammoCount.ToString("00");

    }

    private void TankFuelLightColor()
    {
        if (tank.fuel < 40)
        {
            if (timer >= 0f)
            {
                timer -= 0.1f;
            }
            else
            {
                if (fuelLight.color != Color.red)
                {
                    fuelLight.color = Color.red;
                }
                else
                {
                    fuelLight.color = Color.black;
                }
                timer = 1f;
            }

        }
        else
        {
            fuelLight.color = Color.green;
        }

    }

    private void SwapControls()
    {
        if (Input.GetButtonDown("Swap"))
        {
            if (collided)
            {
                if (inTank)
                {
                    turrets.enabled = false;
                    grabbing.enabled = true;
                    playMove.enabled = true;
                    inTank = false;
                    fuelLight.enabled = false;
                    ammoDisplay.enabled = false;
                    ammoText.enabled = false;
                    progressBar.gameObject.SetActive(false);
                    playerRigBody.constraints = RigidbodyConstraints2D.None;
                    playerRigBody.constraints = RigidbodyConstraints2D.FreezeRotation;
                    currentAudio = tankIn;
                    tankBody.enabled = false;
                    if (tank.canMove)
                    {
                        CameraShaker.Instance.StartShake(0.1f, 1f, 0.1f);
                        tankIn.Play();
                        tankOut.Stop();
                    }
                }
                else
                {
                    turrets.enabled = true;
                    grabbing.enabled = false;
                    playMove.enabled = false;
                    inTank = true;
                    fuelLight.enabled = true;
                    ammoDisplay.enabled = true;
                    ammoText.enabled = true;
                    progressBar.gameObject.SetActive(true);
                    currentAudio = tankOut;
                    playerRigBody.constraints = RigidbodyConstraints2D.FreezePositionX;
                    CameraShaker.Instance.StartShake(0f, 0f, 0f);
                    tankBody.enabled = true;

                    if (haventTouched)
                    {
                        if (FirstControlContact != null)
                        {
                            FirstControlContact.Invoke();
                        }
                        haventTouched = false;
                    }

                    if (tank.canMove)
                    {
                        tankIn.Stop();
                        tankOut.Play();
                    }
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collided = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collided = false;
        }
    }

  
    
   

}
