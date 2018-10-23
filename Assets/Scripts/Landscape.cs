using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landscape : MonoBehaviour {

    [SerializeField]
    private float force = 9000000f;

    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    private TankManager tank;

   
    // Update is called once per frame
    void Update () {

        if (tank.fuel!=0)
        {
            transform.Translate(Vector2.left * force * Time.deltaTime);
        }
        
    }

   
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "End")
        {
            transform.position = spawnPoint.position;
        }
    }
}
