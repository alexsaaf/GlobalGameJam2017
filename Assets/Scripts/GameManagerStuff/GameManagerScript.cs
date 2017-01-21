using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {

    public Transform[] spawnPositions;

    // The score for the players
    float playerOneScore = 0;
    float playerTwoScore = 0;
    int playerOneCats = 0;
    int playerTwoCats = 0;

    public int numberOfCatsPerTeam = 3;

    public float winScore = 10f;

    private SceneHandler sceneHandler;

    public int bpm = 60;

	// Use this for initialization
	void Start () {
        sceneHandler = GetComponent<SceneHandler>();

	}

    void SpawnCat(int player) {
        Transform pos_one = spawnPositions[Random.Range(0, 3)];
        Transform pos_two = spawnPositions[Random.Range(0, 3)];
        Vector3 direction = pos_one.position - pos_two.position;
        float randomRange = Random.Range(0, 1);

    }
	
	// Update is called once per frame
	void Update () {
        CheckScore();
        
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

    public void UpdateBeat(int bpm) {
        this.bpm = bpm;
    }
}
