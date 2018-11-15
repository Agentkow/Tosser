using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class TankHit : MonoBehaviour {

    [SerializeField]
    private TankManager tank;
    

    [SerializeField]
    private AudioSource hitSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hostile")
        {
            tank.health -= 13;
            hitSound.Play();
            CameraShaker.Instance.ShakeOnce(6f, 8f, 0.1f, 1f);
            collision.gameObject.SetActive(false);
        }
    }
}
