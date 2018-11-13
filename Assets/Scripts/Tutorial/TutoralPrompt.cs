using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoralPrompt : MonoBehaviour {

    [SerializeField]
    private PromptCheck promptCheck;

    private Animator animate;

    // Use this for initialization
    void Start () {
        animate = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

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
