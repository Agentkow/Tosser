using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSpawner : MonoBehaviour {

    [SerializeField]
    private Rigidbody2D enemy;
    [SerializeField]
    private TankManager tank;
    [SerializeField]
    private TutorialManager manager;
    private float force = 150f;
    public bool hasSpawned= false;

    

    // Update is called once per frame
    void Update()
    {

        if (manager.rockSpawned)
        {
            Rigidbody2D rock = Instantiate(enemy, transform.position, transform.rotation);
            rock.velocity = force * this.gameObject.transform.up;
            hasSpawned = true;
            manager.rockSpawned = false;
        }
        
    }
}
