using UnityEngine;

public class InputManager : MonoBehaviour, IInput {

    // TODO: Set colors, somewhere. InputManager does not feel like the
    // natural place to define these.
    public Color colorP1, colorP2;
    private string sequenceP1 = "", sequenceP2 = "";
	
	// Update is called once per frame
	void Update () {
        if (sequenceP1.Length == 4) {
            // Send player 1 is finished
            PusherHandler.instance.ActivatePusher(sequenceP1, colorP1);
            sequenceP1 = "";
        }
        if (sequenceP1.Length == 4) {
            // Send player 2 is finished
            PusherHandler.instance.ActivatePusher(sequenceP2, colorP2);
            sequenceP2 = "";
        }
	}

    public void playA(int playerNumber) {
        switch (playerNumber) {
            case 1:
                sequenceP1 += "A";
                break;
            case 2:
                sequenceP2 += "A";
                break;
        }
    }

    public void playE(int playerNumber) {
        switch(playerNumber) {
            case 1:
                sequenceP1 += "E";
                break;
            case 2:
                sequenceP2 += "E";
                break;
        }
    }

    public void playD(int playerNumber) {
        switch (playerNumber) {
            case 1:
                sequenceP1 += "D";
                break;
            case 2:
                sequenceP2 += "D";
                break;
        }
    }

    public void playG(int playerNumber) {
        switch (playerNumber) {
            case 1:
                sequenceP1 += "G";
                break;
            case 2:
                sequenceP2 += "G";
                break;
        }
    }

    // TODO: Send sequence of played notes to PusherHandler, if played successfully.
}
