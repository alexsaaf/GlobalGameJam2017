using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatScript : MonoBehaviour {

    public float score;
    public int playerNumber;
	
	// Update is called once per frame
	void Update () {
	}

    public void OnDeath () {
        GameObject.Find("GameManager").GetComponent<GameManagerScript>().AddScore(playerNumber, score);
        GameObject.Destroy(gameObject);
    }
}
