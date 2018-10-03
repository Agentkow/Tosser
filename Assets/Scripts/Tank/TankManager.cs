using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankManager : MonoBehaviour {

    
    [SerializeField]
    private Text healthPercentage;

    [SerializeField]
    private Text fuelGauge;
    
    [SerializeField]
    private GameObject modeSwap;

    [SerializeField]
    private Slider progressInTank;

    [SerializeField]
    private GameManager manager;

    [SerializeField]
    private GameObject player;

    private Transform startPosition;

    public Slider progressInfo;

    public float fuel = 100;
    private float maxFuel = 100;

    public float health = 100;
    private float fuelDropSpeed = 0.03f;
    public float progressSpeed = 0.1f;

    public bool fullAmmo = false;
    public float ammoCount = 0f;
    public float maxAmmo = 20f;
    
    
    public GameObject loadedAmmo;

    void Start()
    {
        progressInfo = progressInTank;
        startPosition = player.transform;
    }


    void Update()
    {
        if (ammoCount == maxAmmo)
        {
            fullAmmo = true;
        }

        
    }

    // Update is called once per frame
    void FixedUpdate () {

        healthPercentage.text = health.ToString("000") + "%";
        fuelGauge.text = Mathf.RoundToInt(fuel).ToString("000");

        if (ammoCount>=maxAmmo)
        {
            ammoCount = maxAmmo;
        }

        if (fuel>maxFuel)
        {
            fuel = maxFuel;
        }

        if (fuel >=0)
        {
            StartCoroutine(Progressing());
            progressInTank.value += progressSpeed;
            fuel-= fuelDropSpeed;
        }

	}

    IEnumerator Progressing()
    {
        yield return new WaitForSeconds(2);
        
    }

    public void Reset()
    {
        progressInTank.value = 0;
        player.transform.position = startPosition.position;
        ammoCount = 0;
    }


}
