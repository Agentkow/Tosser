using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadLight : MonoBehaviour {

    [SerializeField]
    private TankManager tank;

    private Color reloaded = Color.green;
    private Color empty = Color.gray;
    [SerializeField]
    private Image img;

    void Update()
    {
        if (tank.fullAmmo)
        {
            img.color = reloaded;
        }
        else if (tank.ammoCount == 0)
        {
            img.color = empty;
        }
    }
}
