using UnityEngine;

/// <summary>
/// This class is used to manage the input received by the players during the game.
/// It keeps track of how close they are to the beat and sends successful/unsuccessful
/// inputs to UIController and PusherHandler.
/// </summary>
public class InputManager : IInput {

    // TODO: Set colors, somewhere. InputManager does not feel like the
    // natural place to define these.
    public Color colorP1, colorP2;
    private string sequenceP1 = "", sequenceP2 = "";
    private float beatMargin = 0.5f;
    private UIController ui;

    public InputManager(UIController ui) {
        this.ui = ui;
    }
	
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
        // TODO: Call UIController to update UI for each successful tone

        switch(playerNumber) {
            case 1:
                if (GetTimeToBeat() <= beatMargin) {
                    sequenceP1 += tone;
                    ui.UpdatePlayerSequence(playerNumber, sequenceP1);
                    if (sequenceP1.Length == 4) {
                        PusherHandler.instance.ActivatePusher(sequenceP1, colorP1);
                        sequenceP1 = "";
                    }
                } else {
                    // Player 1 is off beat - send error
                    sequenceP1 = "";
                }
                break;
            case 2:
                if (GetTimeToBeat() <= beatMargin) {
                    sequenceP2 += tone;
                    ui.UpdatePlayerSequence(playerNumber, sequenceP2);
                    if (sequenceP2.Length == 4) {
                        PusherHandler.instance.ActivatePusher(sequenceP2, colorP2);
                        sequenceP2 = "";
                    }
                } else {
                    // Player 2 is off beat - send error
                    sequenceP2 = "";
                }
                break;
            default:
                Debug.Log("Player number " + playerNumber + "is not defined in InputManager");
                break;
        }
    }

    // Placeholder function that returns how long time the closest beat is.
    // This means that it should return the time SINCE the last beat or the time UNTIL
    // the next beat, depending on which one is nearest.
    // TODO: Implement this function once the GameManager actually keeps a beat.
    private float GetTimeToBeat() {
        return 0f;
    }
    
}
