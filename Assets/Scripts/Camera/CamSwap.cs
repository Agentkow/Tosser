using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwap : MonoBehaviour {


    [SerializeField]
    private Camera mainCam;

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

    private CameraShake camShake;

    void Start()
    {
        camPos = mainCam.transform;
        camShake = gameObject.GetComponent<CameraShake>();
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
                    camPos.position = camPos.position - new Vector3(outPosition, 0, 0);
                    camShake.mainCamPos = camPos.position;
                    control = false;
                }
                else
                {
                    mainCam.orthographicSize = outSize;
                    camPos.position = camPos.position + new Vector3(outPosition, 0, 0);
                    camShake.mainCamPos = camPos.position;
                    control = true;
                }
            }
            
            
        }
    }
}
