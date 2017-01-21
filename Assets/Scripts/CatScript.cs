﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatScript : MonoBehaviour {

    public float score;
    public int playerNumber;
    public AudioClip meow1;
    public AudioClip meow2;
    public int minMeowCooldown;
    public int maxMeowCooldown;
    private float meowTimer = 0;
    public Sprite pearSprite;
    public Sprite raspSprite;
	
	// Update is called once per frame
	void Update () {
        if(meowTimer <= 0) {
            int meowPicker = Random.Range(0, 2);
            if(meowPicker == 0) {
                AudioSource.PlayClipAtPoint(meow1, transform.position);
            } else {
                AudioSource.PlayClipAtPoint(meow2, transform.position);
            }
            meowTimer += Random.Range(minMeowCooldown, maxMeowCooldown);
        } else {
            meowTimer -= Time.deltaTime;
        }
	}

    public void OnDeath () {
        GameObject.Find("GameManager").GetComponent<GameManagerScript>().AddScore(playerNumber, score);
        GameObject.Destroy(gameObject);
    }

    public void AssignPlayer(int playerNumber) {
        this.playerNumber = playerNumber;
        SpriteRenderer renderer = (SpriteRenderer)GetComponent("SpriteRenderer");
        if (playerNumber == 0) {
            renderer.sprite = pearSprite;
        } else {
            renderer.sprite = raspSprite;
        }
    }
}
