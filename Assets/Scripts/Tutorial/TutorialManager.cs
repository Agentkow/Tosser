using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour {

    [SerializeField]
    private Text frontText;

    [SerializeField]
    private TankManager tank;

    [SerializeField]
    private GameObject fuelSpawnArrow;
    [SerializeField]
    private GameObject fuelDropArrow;
    [SerializeField]
    private GameObject ammoSpawnArrow;
    [SerializeField]
    private GameObject ammoDropArrow;
    [SerializeField]
    private GameObject controlPanelArrow;


    // Use this for initialization
    void Start () {
        tank.fuel = 0;
        frontText.text = "";

        fuelSpawnArrow.SetActive(true);

	}

    private void OnFirstFuelSpawned()
    {
        fuelSpawnArrow.SetActive(false);
    }

    private void OnFirstFuelDestroyed()
    {
        fuelDropArrow.SetActive(false);
    }

    private void OnFirstAmmoSpawned()
    {
        ammoSpawnArrow.SetActive(false);
    }

    private void OnEnable()
    {

        Spawner.FirstFuelSpawned += OnFirstFuelSpawned;

        if (fuelSpawnArrow.activeSelf == false)
        {
            Engine.FirstFuelDestroyed += OnFirstFuelDestroyed;
        }

        if (fuelDropArrow.activeSelf == false)
        {
            Spawner.FirstAmmoSpawned += OnFirstAmmoSpawned;
        }
        if (true)
        {

        }
        if (true)
        {

        }

    }

    private void OnDisable()
    {

        Spawner.FirstFuelSpawned -= OnFirstFuelSpawned;

        if (fuelSpawnArrow.activeSelf == false)
        {
            fuelDropArrow.SetActive(true);
        }
        if (true)
        {

        }
        if (true)
        {

        }
        if (true)
        {

        }

    }
    // Update is called once per frame
    void Update () {
		
	}
}
