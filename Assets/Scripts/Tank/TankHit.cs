using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankHit : MonoBehaviour {

    [SerializeField]
    private TankManager tank;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hostile")
        {
            tank.health -= 13;
            collision.gameObject.SetActive(false);
        }
    }
}
