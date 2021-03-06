﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwap : MonoBehaviour {


    [SerializeField]
    private Camera mainCam;
    [SerializeField]
    private Transform position;

    private float inSize = 6f;
    private float outSize = 46f;
    private float outPosition = 53.7f;

    [SerializeField]
    private Vector3 inPos;
    [SerializeField]
    private Vector3 outPos;

    private Transform camPos;

    [SerializeField]
    private GameObject fireControls;
    [SerializeField]
    private bool collideCheck;
    [SerializeField]
    private bool control = false;
    

    void Start()
    {
        camPos = mainCam.transform;
    }

    // Update is called once per frame
    void Update()
    {
        collideCheck = fireControls.GetComponent<SwapModes>().collided;

        if (Input.GetButtonDown("Swap"))
        {
            if (collideCheck)
            {
                if (control)
                {
                    mainCam.orthographicSize = inSize;
                    position.position = new Vector3(inPos.x,inPos.y,inPos.z);
                    camPos.position = camPos.position - new Vector3(outPosition, 0, 0);
                    control = false;
                }
                else
                {
                    mainCam.orthographicSize = outSize;
                    position.position = new Vector3(outPos.x, outPos.y, outPos.z);
                    camPos.position = camPos.position + new Vector3(outPosition, 0, 0);
                    control = true;
                }
            }
            
            
        }
    }
}
