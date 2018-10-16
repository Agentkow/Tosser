using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadLight : MonoBehaviour {

    [SerializeField]
    private TankManager tank;

    [SerializeField]
    private Image img;

    [SerializeField]
    private GameObject lighting;

    private Color reloaded = Color.green;
    private Color empty = Color.gray;

    private void Start()
    {
        lighting.gameObject.SetActive(false);
    }

    void Update()
    {
        if (tank.fullAmmo)
        {
            img.color = reloaded;
            lighting.gameObject.SetActive(true);
        }
        else if (tank.ammoCount == 0)
        {
            img.color = empty;
            lighting.gameObject.SetActive(false);
        }
    }
}
