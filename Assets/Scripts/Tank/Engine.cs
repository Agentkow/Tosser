using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour {

    [SerializeField]
    private TankManager tank;
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "GrabObject")
        {
            if (collision.gameObject.name == "Fuel(Clone)")
            {
                tank.fuel += 100;
            }
            else
            {
                tank.health -= 5;
            }
            Destroy(collision.gameObject);
        }
    }
}
