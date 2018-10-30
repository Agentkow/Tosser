using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialPrompt : MonoBehaviour {

    [SerializeField]
    private Text tutorialPrompt;

    [SerializeField]
    private GrabAndThrow grabFunction;

    // Use this for initialization
    void Start () {
        tutorialPrompt.text = "";
	}
	
	// Update is called once per frame
	void Update () {

        if (grabFunction.grabbed)
        {
            tutorialPrompt.text = "L Mouse to grab";
        }
        else
        {
            tutorialPrompt.text = "";
        }
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
