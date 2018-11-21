using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionsText : MonoBehaviour {

    [SerializeField]
    private Text instructions;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        string[] name = Input.GetJoystickNames();
        if (true)
        {

        }
        else
        {
            instructions.text = "In Tank: Movement - A & D / Left & Right Arrow " +
                "Grab / Throw Objects - Left Mouse Jump - Space Interact with controls - E On Cannon: Raise / Lower Cannon - A & D / Left & Right Arrow Fire Cannon - Left Mouse Leave Controls - E";
        }
	}
}
