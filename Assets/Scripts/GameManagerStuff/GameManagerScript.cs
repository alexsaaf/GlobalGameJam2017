using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {


    // The score for the players
    public float playerOneScore = 0;
    public float playerTwoScore = 0;

    public float winScore = 10f;

    private SceneHandler sceneHandler;

	// Use this for initialization
	void Start () {
        sceneHandler = GetComponent<SceneHandler>();
	}
	
	// Update is called once per frame
	void Update () {
		if (playerOneScore >= winScore || playerTwoScore >= winScore) {
            sceneHandler.LoadEndScene();
        }
        if (Input.GetButtonDown("EndGame")) {
            sceneHandler.LoadMainMenu();
        }
        if (Input.GetButtonDown("Next")) {
            Debug.Log("Loading the NExt scene");
            sceneHandler.LoadNextScene();
        }
    }
}
