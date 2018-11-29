using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseOverSound : MonoBehaviour {

    [SerializeField]
    private AudioSource menuSound;

    void OnMouseOver()
    {
        Debug.Log("hit");
        menuSound.Play();
    }
}
