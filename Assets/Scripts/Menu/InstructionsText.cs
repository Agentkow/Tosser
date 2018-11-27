using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionsText : MonoBehaviour {

    [SerializeField]
    private Text instructionsPC;
    [SerializeField]
    private Text instructionsGamePad;

    // Use this for initialization
    void Awake () {
        instructionsGamePad.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetAxisRaw("Horizontal") >0)
        {
            instructionsPC.enabled = true;
            instructionsGamePad.enabled = false;
        }
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            instructionsPC.enabled = false;
            instructionsGamePad.enabled = true;
        }
	}
}
