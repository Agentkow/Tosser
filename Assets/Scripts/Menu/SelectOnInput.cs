using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectOnInput : MonoBehaviour {

    [SerializeField]
    private EventSystem eventSystem;

    [SerializeField]
    private GameObject selectedObject;

    private bool buttonSelected;

    [SerializeField]
    private AudioSource menuClick;
    
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxisRaw("Vertical")!=0)
        {
            menuClick.Play();
        }
		if(Input.GetAxisRaw("Vertical") != 0 && !buttonSelected)
        {
            eventSystem.SetSelectedGameObject(selectedObject);
            buttonSelected = true;
            
        }
	}

    private void OnDisable()
    {
        buttonSelected = false;
    }
}
