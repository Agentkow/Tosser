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

    private void OnEnable()
    {
        Spawner.FirstFuelSpawned += OnFirstFuelSpawned;
    }

    private void OnDisable()
    {
        Spawner.FirstFuelSpawned -= OnFirstFuelSpawned;
    }
    // Update is called once per frame
    void Update () {
		
	}
}
