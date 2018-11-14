using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

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

    public static event Action FirstControlContact;


    float timeStamp = 0;
    // Use this for initialization
    void Start () {
        fuelLight.enabled = false;
        ammoDisplay.enabled = false;
        ammoText.enabled = false;
        progressBar.gameObject.SetActive(false);
        turrets = player.GetComponent<TurretControls>();
        grabbing = player.GetComponent<GrabAndThrow>();
        playMove = player.GetComponent<PlayerMovement>();
        playerRigBody = player.GetComponent<Rigidbody2D>();
        currentAudio = tankIn;
        tankBody.enabled = false;
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
        //if (tank.fuel < 70)
        //{
        //    StartCoroutine(FuelLightOn());
        //    StartCoroutine(FuelLightOff());
        //}
        //else
        //{
        //    fuelLight.color = Color.green;
        //}


        if (tank.fuel < 70)
        {
            Debug.Log("ActualTime" + Math.Abs(Time.time) + "Timestamp" + timeStamp);

            if (Math.Abs(Time.time) == timeStamp + 2)
            {
                if (fuelLight.color == Color.green || fuelLight.color == Color.black)
                    fuelLight.color = Color.red;
                else
                    fuelLight.color = Color.black;

                timeStamp = Math.Abs(Time.time);
            }


        }
        else
        {
                fuelLight.color = Color.green;

            timeStamp = Math.Abs(Time.time);
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

    IEnumerator FuelLightOn()
    {
        yield return new WaitForSeconds(1);
        fuelLight.color = Color.red;
    }
    IEnumerator FuelLightOff()
    {
        
        yield return new WaitForSeconds(1);
        fuelLight.color = Color.black;
    }

}
