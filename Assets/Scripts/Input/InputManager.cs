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
    private float beatMargin;
    private UIController ui;
    private BeatController beatController;
    private bool hitToneP1, hitToneP2;
    private bool toneStreakP1, toneStreakP2;
    private bool count;
    private float timer;

    private float calibration = 0.15f; 

    public InputManager(UIController ui, BeatController beatController) {
        this.ui = ui;
        this.beatController = beatController;
        if (beatController == null) {
            Debug.Log("BeatController is null in InputManager constructor");
        } else {
            // This value is just a small part of the total time, modify the divider if needed;
            beatMargin = beatController.GetTimeBetweenBeats() / 8f;
            Debug.Log("Margin: " + beatMargin);
        }
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
        switch(playerNumber) {
            case 1:
                if (GetTimeToBeat() <= beatMargin) {
                    toneStreakP1 = true;
                    hitToneP1 = true;
                    sequenceP1 += tone;
                    ui.UpdatePlayerSequence(playerNumber, sequenceP1);
                    if (sequenceP1.Length == 4) {
                        PusherHandler.instance.ActivatePusher(sequenceP1, colorP1);
                        sequenceP1 = "";
                    }
                } else {
                    MissedTone(playerNumber, ref sequenceP1);
                    toneStreakP1 = false;
                }
                break;
            case 2:
                Debug.Log("Time to beat: " + (GetTimeToBeat()));
                if (GetTimeToBeat() <= beatMargin) {
                    toneStreakP2 = true;
                    hitToneP2 = true;
                    sequenceP2 += tone;
                    ui.UpdatePlayerSequence(playerNumber, sequenceP2);
                    if (sequenceP2.Length == 4) {
                        PusherHandler.instance.ActivatePusher(sequenceP2, colorP2);
                        sequenceP2 = "";
                    }
                } else {
                    MissedTone(playerNumber, ref sequenceP2);
                    toneStreakP2 = false;
                }
                break;
            default:
                Debug.Log("Player number " + playerNumber + "is not defined in InputManager");
                break;
        }
    }

    // Returns the closest beat.
    // This means that it should return the time SINCE the last beat or the time UNTIL
    // the next beat, depending on which one is nearest.
    private float GetTimeToBeat() {
        return beatController.TimeToBeat();
    }

    public void Beat() {
        count = true;
        timer = 0;
    }

    public void Update() {
        if (count) {
            timer += Time.deltaTime;
            if (timer >= beatMargin) {
                if (!hitToneP1 && toneStreakP1) {
                    toneStreakP1 = false;
                    MissedTone(1, ref sequenceP1); 
                }
                if (!hitToneP2 && toneStreakP2) {
                    toneStreakP2 = false;
                    MissedTone(2, ref sequenceP2);
                }
                count = false;
                hitToneP1 = false;
                hitToneP2 = false;
            }
        }
    }

    private void MissedTone(int playerNumber, ref string sequence) {
        ui.IncorrectSequence(playerNumber);
        sequence = "";
    }
    
}
