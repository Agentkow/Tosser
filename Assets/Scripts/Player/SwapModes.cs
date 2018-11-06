using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private TurretControls turrets;
    private GrabAndThrow grabbing;
    private PlayerMovement playMove;
    public AudioSource currentAudio;
    
    public bool collided = false;

    [SerializeField]
    private Image fuelLight;
    
    // Use this for initialization
    void Start () {
        fuelLight.enabled = false;
        ammoDisplay.enabled = false;
        ammoText.enabled = false;
        progressBar.gameObject.SetActive(false);
        turrets = player.GetComponent<TurretControls>();
        grabbing = player.GetComponent<GrabAndThrow>();
        playMove = player.GetComponent<PlayerMovement>();
        currentAudio = tankIn;
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
        if (tank.fuel < 30)
        {
            fuelLight.color = Color.red;
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
                    grabbing.enabled = true;
                    playMove.enabled = true;
                    turrets.enabled = false;
                    inTank = false;
                    fuelLight.enabled = false;
                    ammoDisplay.enabled = false;
                    ammoText.enabled = false;
                    progressBar.gameObject.SetActive(false);
                    currentAudio = tankIn;
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
