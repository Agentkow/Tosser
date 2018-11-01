using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PromptCheck : MonoBehaviour {

    [SerializeField]
    private Text tutorialPrompt;

    [SerializeField]
    private GrabAndThrow grabCode;

    void Start()
    {
        tutorialPrompt.text = "";
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GrabObject" && !grabCode.grabbed)
        {
            tutorialPrompt.text = "L Mouse to grab";
        }
        else if (collision.gameObject.tag == "GunControls")
        {
            tutorialPrompt.text = "E to Interact";
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        tutorialPrompt.text = "";
    }
}
