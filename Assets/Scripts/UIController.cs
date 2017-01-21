using System.Collections;
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
    public float shrinkSpeed;

	void Start () {
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

        gm = GameObject.Find("GameManager").GetComponent<GameManagerScript>();

        originalBeatSize = beat1.rectTransform.sizeDelta;
    }
	
	void Update () {
        player1.pointBar.fillAmount = gm.GetFillAmount(1);
        player2.pointBar.fillAmount = gm.GetFillAmount(2);

        float oldSize = beat1.rectTransform.sizeDelta.x;
        print(oldSize);
        beat1.rectTransform.sizeDelta = new Vector2(oldSize - shrinkSpeed, oldSize - shrinkSpeed);
        beat2.rectTransform.sizeDelta = new Vector2(oldSize - shrinkSpeed, oldSize - shrinkSpeed);
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
        beat1.rectTransform.sizeDelta = originalBeatSize;
        beat2.rectTransform.sizeDelta = originalBeatSize;
    }

    public struct Player {
        public Image pointBar;
        public Text symbol1, symbol2, symbol3, symbol4;
        public Color eColor, dColor, gColor, aColor;

        public void UpdateSequence(string sequence) {
            char[] characters = sequence.ToCharArray();
            AssignSymbol(symbol1, characters[0]);
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

        }
    }
}
