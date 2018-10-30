using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    [SerializeField]
    private TankManager tank;

    [SerializeField]
    private Text endMission;
    

    public bool cleared = false;

    // Use this for initialization
    void Start () {
        
        StartCoroutine(ClearScreen());
    }
	
	// Update is called once per frame
	void Update () {

        if (tank.health <= 0)
        {
            endMission.text = "MISSION FAILED!";
            StartCoroutine(ReturnToMainMenu());
        }

        if (tank.progressInfo.value >= tank.progressInfo.maxValue)
        {
            endMission.fontStyle = FontStyle.BoldAndItalic;
            endMission.text = "MISSION CLEARED!";
            StartCoroutine(ReturnToMainMenu());
            
        }

        if (Input.GetButton("Cancel"))
        {
            SceneManager.LoadScene("Menu");
        }
    }

    IEnumerator ReturnToMainMenu()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Menu");
    }

    IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(2);
        tank.Reset();
        
    }
    IEnumerator ClearScreen()
    {
        endMission.fontStyle = FontStyle.Bold;
        endMission.text = "DEPLOY";
        yield return new WaitForSeconds(2);
        endMission.text = "";
    }

}
