using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skip : MonoBehaviour {

    [SerializeField]
    private Text skipText;

    private float axisNum;

    // Use this for initialization
    void Start () {
        axisNum = Input.GetJoystickNames()[0].Length;
    }

    private void FixedUpdate()
    {
        axisNum = Input.GetJoystickNames()[0].Length;
    }
    // Update is called once per frame
    void Update () {


        if (axisNum==33)
        {
            skipText.text = "Press Start to skip";
        }
        else
        {
            skipText.text = "Press Enter to skip";
        }
	}
}
