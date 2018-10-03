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
    
    public float level = 1;

    public bool cleared = false;

    // Use this for initialization
    void Start () {
        
        StartCoroutine(ClearScreen());
    }
	
	// Update is called once per frame
	void Update () {

        if (tank.health <= 0)
        {
            endMission.text = "FAILED!";
            StartCoroutine(RestartLevel());
        }

        if (tank.progressInfo.value >= 1000)
        {
            if (level<3)
            {
                endMission.text = "LEVEL CLEARED!";
                StartCoroutine(RestartLevel());
                StartCoroutine(ClearScreen());
            }
            else if (level>=3)
            {
                endMission.text = "MISSION CLEARED!";
                level = 1;
                StartCoroutine(ReturnToMainMenu());
            }
        }

        if (Input.GetButton("Cancel"))
        {

        }
    }

    IEnumerator ReturnToMainMenu()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("Menu");
    }

    IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(5);
        tank.Reset();
        
    }
    IEnumerator ClearScreen()
    {
        endMission.text = "Level " + level.ToString();
        yield return new WaitForSeconds(2);
        endMission.text = "";
    }

}
