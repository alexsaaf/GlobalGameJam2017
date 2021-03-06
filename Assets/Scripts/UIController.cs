﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    GameManagerScript gm;

    public Color eColor;
    public Color aColor;
    public Color dColor;
    public Color gColor;

    Player player1;
    Player player2;

    Image beat1;
    Image beat2;

    Vector2 originalBeatSize;
    public float alphaSpeed;

	void Start () {

        gm = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        
        //Get all the components and store them in the player
        player1 = new Player();
        player1.pointBar = transform.GetChild(0).GetChild(2).GetComponent<Image>();
        Transform symbolHolder = transform.GetChild(0).GetChild(3);
        player1.symbol1 = symbolHolder.GetChild(0).GetComponent<Text>();
        player1.symbol2 = symbolHolder.GetChild(1).GetComponent<Text>();
        player1.symbol3 = symbolHolder.GetChild(2).GetComponent<Text>();
        player1.symbol4 = symbolHolder.GetChild(3).GetComponent<Text>();
        player1.aColor = aColor;
        player1.eColor = eColor;
        player1.dColor = dColor;
        player1.gColor = gColor;
        beat1 = transform.GetChild(0).GetChild(5).GetComponent<Image>();

        //Set the colors to comply with the playercolors
        beat1.color = gm.player1Color;
        player1.pointBar.color = gm.player1Color;
        transform.GetChild(0).GetChild(0).GetComponent<Text>().color = gm.player1Color;

        //Get all the components and store them in the player
        player2 = new Player();
        player2.pointBar = transform.GetChild(1).GetChild(2).GetComponent<Image>();
        symbolHolder = transform.GetChild(1).GetChild(3);
        player2.symbol1 = symbolHolder.GetChild(0).GetComponent<Text>();
        player2.symbol2 = symbolHolder.GetChild(1).GetComponent<Text>();
        player2.symbol3 = symbolHolder.GetChild(2).GetComponent<Text>();
        player2.symbol4 = symbolHolder.GetChild(3).GetComponent<Text>();
        player2.aColor = aColor;
        player2.eColor = eColor;
        player2.dColor = dColor;
        player2.gColor = gColor;
        beat2 = transform.GetChild(1).GetChild(5).GetComponent<Image>();

        //Set the colors to comply with the playercolors
        beat2.color = gm.player2Color;
        player2.pointBar.color = gm.player2Color;
        transform.GetChild(1).GetChild(0).GetComponent<Text>().color = gm.player2Color;

    }
	
	void Update () {
        player1.pointBar.fillAmount = gm.GetFillAmount(1);
        player2.pointBar.fillAmount = gm.GetFillAmount(2);

        beat1.color = new Color(beat1.color.r, beat1.color.g, beat1.color.b, beat1.color.a - alphaSpeed * Time.deltaTime);
        beat2.color = new Color(beat2.color.r, beat2.color.g, beat2.color.b, beat2.color.a - alphaSpeed * Time.deltaTime);

    }

    public void UpdatePlayerSequence(int playerNumber, string sequence) {
        if(playerNumber == 1) {
            player1.UpdateSequence(sequence);
        } else {
            player2.UpdateSequence(sequence);
        }
    }

    public void IncorrectSequence(int playerNumber) {
        if (playerNumber == 1) {
            player1.Error();
        } else {
            player2.Error();
        }
    }

    public void Beat() {
        beat1.color = new Color(beat1.color.r, beat1.color.g, beat1.color.b, 1);
        beat2.color = new Color(beat2.color.r, beat2.color.g, beat2.color.b, 1);
    }

    public struct Player {
        public Image pointBar;
        public Text symbol1, symbol2, symbol3, symbol4;
        public Color eColor, dColor, gColor, aColor;

        public void UpdateSequence(string sequence) {
            char[] characters = sequence.ToCharArray();
            AssignSymbol(symbol1, (characters.Length > 0) ? characters[0] : ' ');
            AssignSymbol(symbol2, (characters.Length > 1) ? characters[1] : ' ');
            AssignSymbol(symbol3, (characters.Length > 2) ? characters[2] : ' ');
            AssignSymbol(symbol4, (characters.Length > 3) ? characters[3] : ' ');
        }

        public void AssignSymbol(Text symbol, char c) {
            string character = c.ToString().ToUpper();
            symbol.text = character;
            switch (character) {
                case "E":
                    symbol.color = eColor;
                    break;
                case "D":
                    symbol.color = dColor;
                    break;
                case "G":
                    symbol.color = gColor;
                    break;
                case "A":
                    symbol.color = aColor;
                    break;
            }
        }

        public void Error() {
            //TODO: Play fail sound effect. Maybe visual feedback as well.
            UpdateSequence("");
        }
    }

}
