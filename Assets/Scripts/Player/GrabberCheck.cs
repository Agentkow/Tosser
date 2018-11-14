using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabberCheck : MonoBehaviour {

    [SerializeField]
    private PlayerMovement playerMove;
    [SerializeField]
    private Transform playerPos;

    private Transform position;

    private float place = 0.5f;

    void Start()
    {
        position = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMove.facingRight)
        {
            position.position = new Vector3(playerPos.position.x + place,playerPos.position.y, playerPos.position.z);
        }
        else
        {
            position.position = new Vector3(playerPos.position.x - place, playerPos.position.y, playerPos.position.z);
        }
    }
}
