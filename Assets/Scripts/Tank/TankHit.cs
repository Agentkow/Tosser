using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankHit : MonoBehaviour {

    [SerializeField]
    private TankManager tank;

    [SerializeField]
    private CameraShake camShake;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hostile")
        {
            tank.health -= 13;
            camShake.Shake(0.3f, 0.4f);
            collision.gameObject.SetActive(false);
        }
    }
}
