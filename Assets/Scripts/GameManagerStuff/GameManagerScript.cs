﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour {

    private  List<Transform> spawnPositions = new List<Transform>();
    public GameObject catPrefab;

    // The score for the players
    float playerOneScore = 0;
    float playerTwoScore = 0;
    int playerOneCats = 0;
    int playerTwoCats = 0;

    float catWorth = 1f;

    public int numberOfCatsPerTeam = 3;

    public float winScore = 10f;

    private SceneHandler sceneHandler;

    public int bpm = 60;

    bool gameOver = false;
    public bool spawnCats = false;
    public bool gameStarting = false;

	// Use this for initialization
	void Start () {
        sceneHandler = GetComponent<SceneHandler>();
        SceneManager.sceneLoaded += OnSceneLoaded;
	}

    void SpawnCat(int player) {
        Transform pos_one = spawnPositions[Random.Range(0, 3)];
        Transform pos_two = spawnPositions[Random.Range(0, 3)];
        if (pos_one != null && pos_two != null) {
            Vector3 direction = pos_one.position - pos_two.position;
            float randomRange = Random.Range(0, 1);

            GameObject obj = Instantiate(catPrefab, pos_one.position + direction * randomRange, Quaternion.identity);
            CatScript cs = obj.GetComponent<CatScript>();
            cs.playerNumber = player;
            cs.score = catWorth;
        } else {
            throw new System.ArgumentException("The postitions (spawn-transfroms) in gamemaneger was not set!");
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (!gameOver) {
            CheckScore();
        }
        if (spawnCats) {
            while (playerOneCats < numberOfCatsPerTeam) {
                SpawnCat(1);
            }
            while (playerTwoCats < numberOfCatsPerTeam) {
                SpawnCat(2);
            }
        }
    }

    void CheckScore() {
        if (playerOneScore >= winScore || playerTwoScore >= winScore) {
            sceneHandler.LoadEndScene();
            gameOver = true;
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

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        if (gameStarting) {
            spawnPositions.Clear();
            GameObject pos_one = GameObject.Find("PosOne");
            GameObject pos_two = GameObject.Find("PosTwo");
            GameObject pos_three = GameObject.Find("PosThree");
            GameObject pos_for = GameObject.Find("PosFor");
            if (pos_one != null) {
            spawnPositions.Add(pos_one.transform);
            }
            if (pos_two != null) {
            spawnPositions.Add(pos_two.transform);
            }
            if (pos_three != null) {
            spawnPositions.Add(pos_three.transform);
            }
            if (pos_for != null) {
            spawnPositions.Add(pos_for.transform);
            }
            gameStarting = false;
            spawnCats = true;
        }
    }

    public void ResetStats() {
        playerOneCats = 0;
        playerOneScore = 0;
        playerTwoCats = 0;
        playerTwoScore = 0;
    }
}
