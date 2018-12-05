using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoralPrompt : MonoBehaviour {

    [SerializeField]
    private PromptCheck promptCheck;

    private Animator animate;
    private float axisNum;

    // Use this for initialization
    void Start () {
        animate = GetComponent<Animator>();

        
       axisNum = Input.GetJoystickNames()[0].Length;
        
    }
	
	// Update is called once per frame
	void Update () {

        if (axisNum == 33)
        {
            animate.SetBool("GamePad", true);
        }
        else if (true)
        {
            animate.SetBool("GamePad", false);
        }

        if (promptCheck.grabbable)
        {
            animate.SetBool("Grabbable", true);
        }
        else
        {
            animate.SetBool("Grabbable", false);
        }

        if (promptCheck.interactable)
        {
            animate.SetBool("Interactable", true);
        }
        else
        {
            animate.SetBool("Interactable", false);
        }
	}
}
