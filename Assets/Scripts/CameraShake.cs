using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {
    
    private Camera cam;

    private float shakeAmount = 0;
    public Vector3 mainCamPos;

    void Awake()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
        mainCamPos = Camera.main.transform.position;
    }
   

    public void Shake(float amt, float length)
    {
        shakeAmount = amt;
        InvokeRepeating("DoShake", 0, 0.01f);
        Invoke("StopShake",length);
    }

    void DoShake()
    {
        if (shakeAmount>0)
        {
            Vector3 camPos = cam.transform.position;

            float offsetX = Random.value * shakeAmount * 2 - shakeAmount;
            float offsetY = Random.value * shakeAmount * 2 - shakeAmount;
            camPos.x += offsetX;
            camPos.y += offsetY;

            cam.transform.position = camPos;
        }
    }

    void StopShake()
    {
        CancelInvoke("DoShake");
        cam.transform.localPosition = mainCamPos;
    }
}
