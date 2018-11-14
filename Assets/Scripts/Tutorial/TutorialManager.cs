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
    private SpriteRenderer fuelSpawnArrow;

    [SerializeField]
    private Spawner fuelSpawn;

    [SerializeField]
    private SpriteRenderer fuelDropArrow;

    [SerializeField]
    private Engine engine;

    [SerializeField]
    private SpriteRenderer ammoSpawnArrow;

    [SerializeField]
    private Spawner ammoSpawn;

    [SerializeField]
    private SpriteRenderer ammoDropArrow;

    [SerializeField]
    private Reload gun;

    [SerializeField]
    private SpriteRenderer controlPanelArrow;

    [SerializeField]
    private SwapModes controlPanel;

    [SerializeField]
    private TutorialSpawner spawner;

    public bool rockSpawned= false;


    // Use this for initialization
    void Start () {
        tank.fuel = 0;
        frontText.text = "";

        controlPanelArrow.enabled = false;
        ammoDropArrow.enabled = false;
        ammoSpawnArrow.enabled = false;
        fuelDropArrow.enabled = false;
        fuelSpawnArrow.enabled = true;

	}

    private void OnFirstFuelSpawned()
    {
        fuelSpawnArrow.enabled = false;
        fuelDropArrow.enabled = true;
    }

    private void OnFirstFuelDestroyed()
    {
        fuelDropArrow.enabled = false;
        ammoSpawnArrow.enabled = true;
    }

    private void OnFirstAmmoSpawned()
    {
        ammoSpawnArrow.enabled = false;
        ammoDropArrow.enabled = true;
    }

    private void OnFirstAmmoDestroyed()
    {
        ammoDropArrow.enabled = false;
        controlPanelArrow.enabled = true;
    }

    private void OnFirstControlPadTouch()
    {
        controlPanelArrow.enabled = false;
        rockSpawned = true;
    }

    private void OnEnable()
    {

        Spawner.FirstFuelSpawned += OnFirstFuelSpawned;

        Engine.FirstFuelDestroyed += OnFirstFuelDestroyed;

        Spawner.FirstAmmoSpawned += OnFirstAmmoSpawned;

        Reload.FirstAmmoDestroyed += OnFirstAmmoDestroyed;

        SwapModes.FirstControlContact += OnFirstControlPadTouch;
        
    }

    private void OnDisable()
    {

        Spawner.FirstFuelSpawned -= OnFirstFuelSpawned;

        Engine.FirstFuelDestroyed -= OnFirstFuelDestroyed;

        Spawner.FirstAmmoSpawned -= OnFirstAmmoSpawned;

        Reload.FirstAmmoDestroyed -= OnFirstAmmoDestroyed;

        SwapModes.FirstControlContact -= OnFirstControlPadTouch;
        

    }
    // Update is called once per frame
    void Update () {

        if (!rockSpawned && spawner.hasSpawned && GameObject.FindGameObjectsWithTag("Hostile").Length <= 0)
        {
            frontText.text = "Tutorial Complete";
            StartCoroutine(TutorialEnd());
        }

	}

    IEnumerator TutorialEnd()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Level");
    }
}
