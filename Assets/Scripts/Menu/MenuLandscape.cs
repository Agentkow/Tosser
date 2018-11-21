using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLandscape : MonoBehaviour {

    [SerializeField]
    private float force = 20f;

    [SerializeField]
    private Transform spawnPoint;
    


    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector2.left * force * Time.deltaTime);
    
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "End")
        {
            transform.position = spawnPoint.position;
        }
    }
}
