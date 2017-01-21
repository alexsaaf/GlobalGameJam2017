using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {


    // The score for the players
    float playerOneScore = 0;
    float playerTwoScore = 0;

    public float winScore = 10f;

    private SceneHandler sceneHandler;

	// Use this for initialization
	void Start () {
        sceneHandler = GetComponent<SceneHandler>();
	}
	
	// Update is called once per frame
	void Update () {
        CheckScore();
        if (Input.GetButtonDown("EndGame")) {
            sceneHandler.LoadMainMenu();
        }
        if (Input.GetButtonDown("Next")) {
            Debug.Log("Loading the NExt scene");
            sceneHandler.LoadNextScene();
        }
    }

    void CheckScore() {
        if (playerOneScore >= winScore || playerTwoScore >= winScore) {
            sceneHandler.LoadEndScene();
        }
    }

    public void AddScore(int player, float score) {
        if (player == 1) {
            playerOneScore += score;
        } else {
            playerTwoScore += score;
        }
        CheckScore();
    }

    public float GetFillAmount(int player) {
        if (player == 1) {
            return playerOneScore / winScore;
        }
        else {
            return playerTwoScore / winScore;
        }
    }
}
