using UnityEngine;

public class InputManager : IInput {

    // TODO: Set colors, somewhere. InputManager does not feel like the
    // natural place to define these.
    public Color colorP1, colorP2;
    private string sequenceP1 = "", sequenceP2 = "";
	
    public void playA(int playerNumber) {
        addToneToSequence("A", playerNumber);
    }

    public void playE(int playerNumber) {
        addToneToSequence("E", playerNumber);
    }

    public void playD(int playerNumber) {
        addToneToSequence("D", playerNumber);
    }

    public void playG(int playerNumber) {
        addToneToSequence("G", playerNumber);
    }

    private void addToneToSequence(string tone, int playerNumber) {
        switch(playerNumber) {
            case 1:
                sequenceP1 += tone;
                if (sequenceP1.Length == 4) {
                    PusherHandler.instance.ActivatePusher(sequenceP1, colorP1);
                    sequenceP1 = "";
                }
                break;
            case 2:
                sequenceP2 += tone;
                if (sequenceP2.Length == 4) {
                    PusherHandler.instance.ActivatePusher(sequenceP2, colorP2);
                    sequenceP2 = "";
                }
                break;
            default:
                Debug.Log("Player number " + playerNumber + "is not defined in InputManager");
                break;
        }
    }
    
}
