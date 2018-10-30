using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour {

    [SerializeField]
    private float time;
    private float currentTime;
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private TankManager tank;
    [SerializeField]
    private GameManager manager;

    void Start()
    {
        currentTime = time;
    }

    // Update is called once per frame
    void Update() {
     currentTime -= 0.5f * Time.deltaTime;
        
            if (currentTime <= 0)
            {
            StartCoroutine(SpawnEnemy());
            currentTime = time;
            }
        
	}

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(time);
        Instantiate(enemy, transform.position, transform.rotation);

    }
}
