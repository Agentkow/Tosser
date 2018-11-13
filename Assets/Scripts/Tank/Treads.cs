using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treads : MonoBehaviour {

    [SerializeField]
    private TankManager tank;

    private Animator animate;

	// Use this for initialization
	void Start () {
        animate = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        if (tank.canMove)
        {
            animate.SetBool("Treads", true);
        }
        else
        {
            animate.SetBool("Treads", false);
        }

	}
}
