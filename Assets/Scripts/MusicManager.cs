using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

    private AudioSource music;

    private Scene levelScene;
    // Use this for initialization
    void Start () {
        music = GetComponent<AudioSource>();
        levelScene = SceneManager.GetActiveScene();
        DontDestroyOnLoad(this.gameObject);
    }

    void FixedUpdate()
    {
        levelScene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update () {


        if (levelScene.name != "Menu")
        {
            music.Play();
        }
    }
}
