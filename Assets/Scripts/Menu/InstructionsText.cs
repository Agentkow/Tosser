using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionsText : MonoBehaviour {

    [SerializeField]
    private Text instructionsPC;
    [SerializeField]
    private Text instructionsGamePad;

    private float axisNum;

    // Use this for initialization
    void Awake () {
        instructionsGamePad.enabled = false;
        axisNum = Input.GetJoystickNames()[0].Length;
    }
	
	// Update is called once per frame
	void Update () {
        
        if (axisNum == 33)
        {
            instructionsPC.enabled = false;
            instructionsGamePad.enabled = true;
        }
        else
        {
            instructionsPC.enabled = true;
            instructionsGamePad.enabled = false;
        }
	}
}
