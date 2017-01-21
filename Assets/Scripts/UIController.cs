using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    GameManagerScript gm;

    public static Color eColor;
    public static Color aColor;
    public static Color dColor;
    public static Color gColor;

    Player player1;
    Player player2;

	void Start () {
        player1 = new Player();
        player1.pointBar = transform.GetChild(0).GetChild(2).GetComponent<Image>();
        Transform symbolHolder = transform.GetChild(0).GetChild(3);
        player1.symbol1 = symbolHolder.GetChild(0).GetComponent<Text>();
        player1.symbol2 = symbolHolder.GetChild(1).GetComponent<Text>();
        player1.symbol3 = symbolHolder.GetChild(2).GetComponent<Text>();
        player1.symbol4 = symbolHolder.GetChild(3).GetComponent<Text>();

        player2 = new Player();
        player2.pointBar = transform.GetChild(1).GetChild(2).GetComponent<Image>();
        symbolHolder = transform.GetChild(1).GetChild(3);
        player2.symbol1 = symbolHolder.GetChild(0).GetComponent<Text>();
        player2.symbol2 = symbolHolder.GetChild(1).GetComponent<Text>();
        player2.symbol3 = symbolHolder.GetChild(2).GetComponent<Text>();
        player2.symbol4 = symbolHolder.GetChild(3).GetComponent<Text>();

        gm = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }
	
	void Update () {
        player1.pointBar.fillAmount = gm.GetFillAmount(1);
        player2.pointBar.fillAmount = gm.GetFillAmount(2); 
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

    }

    public struct Player {
        public Image pointBar;
        public Text symbol1, symbol2, symbol3, symbol4;

        public void UpdateSequence(string sequence) {
            char[] characters = sequence.ToCharArray();
            AssignSymbol(symbol1, characters[0]);
            AssignSymbol(symbol1, (characters.Length > 1) ? characters[1] : ' ');
            AssignSymbol(symbol1, (characters.Length > 2) ? characters[2] : ' ');
            AssignSymbol(symbol1, (characters.Length > 3) ? characters[3] : ' ');
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

        }
    }

}
