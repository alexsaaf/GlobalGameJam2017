using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AquireWinner : MonoBehaviour {

    GameManagerScript MGS;
    Text winnerText;

	// Use this for initialization
	void Start () {
        MGS = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        winnerText = GetComponent<Text>();
        winnerText.text = winnerText.text + MGS.GetWinner();
	}
}
