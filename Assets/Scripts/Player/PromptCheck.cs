using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PromptCheck : MonoBehaviour {

    [SerializeField]
    private GameObject tutorialPrompt;

    [SerializeField]
    private Animator animate;
    
    [SerializeField]
    private GrabAndThrow grabCode;

    public bool grabbable;
    public bool interactable;

    void Start()
    {
        grabbable = false;
        interactable = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GrabObject" && !grabCode.grabbed)
        {
            grabbable = true;
        }

        if (collision.gameObject.tag == "GunControls")
        {
            interactable = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        grabbable = false;
        interactable = false;
    }
}
