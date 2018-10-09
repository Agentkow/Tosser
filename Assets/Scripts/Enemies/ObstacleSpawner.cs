using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

    [SerializeField]
    private float time;
    private float currentTime;
    [SerializeField]
    private Rigidbody2D enemy;
    [SerializeField]
    private TankManager tank;
    [SerializeField]
    private GameManager manager;
    private float force = 150f;
    

    void Start()
    {
        currentTime = time;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1f * Time.deltaTime;
        
            if (currentTime <= 0)
            {
                StartCoroutine(SpawnEnemy());
                currentTime = time;
            }
        
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(time);
        Rigidbody2D rock = Instantiate(enemy, transform.position, transform.rotation);
        rock.velocity = force * this.gameObject.transform.up;
    }
}
