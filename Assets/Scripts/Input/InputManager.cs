using UnityEngine;

/// <summary>
/// This class is used to manage the input received by the players during the game.
/// It keeps track of how close they are to the beat and sends successful/unsuccessful
/// inputs to UIController and PusherHandler.
/// </summary>
public class InputManager : IInput {

    // TODO: Set colors, somewhere. InputManager does not feel like the
    // natural place to define these.
    private Color colorP1, colorP2;
    private string sequenceP1 = "", sequenceP2 = "";
    private float beatMargin;
    private UIController ui;
    private BeatController beatController;
    private bool hitToneP1, hitToneP2;
    private bool toneStreakP1, toneStreakP2;
    private bool count;
    private float timer;

    private float calibration;

    private AudioClip A1, E1, D1, G1, A2, E2, D2, G2;

    public InputManager(UIController ui, BeatController beatController, Color colorP1, Color colorP2, 
        AudioClip A1, AudioClip E1, AudioClip D1, AudioClip G1, AudioClip A2, AudioClip E2, AudioClip D2, AudioClip G2) {
        this.ui = ui;
        this.beatController = beatController;
        if (beatController == null) {
            Debug.Log("BeatController is null in InputManager constructor");
        } else {
            // This value is just a small part of the total time, modify the divider if needed.
            beatMargin = beatController.GetTimeBetweenBeats() / 20f;
            calibration = beatMargin * 2f;
        }
        this.colorP1 = colorP1;
        this.colorP2 = colorP2;
        this.A1 = A1;
        this.E1 = E1;
        this.D1 = D1;
        this.G1 = G1;
        this.A2 = A2;
        this.E2 = E2;
        this.D2 = D2;
        this.G2 = G2;
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
        float timeToBeat = GetTimeToBeat();
        float absoluteTimeToBeat = Mathf.Abs(timeToBeat);
        AudioClip clipToPlay;
        switch (playerNumber) {
            case 1:
                switch(tone) {
                    case "A":
                        clipToPlay = A1;
                        break;
                    case "E":
                        clipToPlay = E1;
                        break;
                    case "D":
                        clipToPlay = D1;
                        break;
                    case "G":
                        clipToPlay = G1;
                        break;
                    default:
                        clipToPlay = A1;
                        break;
                }
                AudioSource.PlayClipAtPoint(clipToPlay, new Vector3(0, 0, 0));
                if (timeToBeat < 0) { // The player hit BEFORE a beat
                    if (timeToBeat + calibration * 4 * beatMargin <= beatMargin) {
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
                } else { // The player hit AFTER a beat
                    if (absoluteTimeToBeat - calibration * 7 * beatMargin <= beatMargin) {
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
                }
                break;
            case 2:
                switch (tone) {
                    case "A":
                        clipToPlay = A2;
                        break;
                    case "E":
                        clipToPlay = E2;
                        break;
                    case "D":
                        clipToPlay = D2;
                        break;
                    case "G":
                        clipToPlay = G2;
                        break;
                    default:
                        clipToPlay = A2;
                        break;
                }
                AudioSource.PlayClipAtPoint(clipToPlay, new Vector3(0, 0, 0));
                if (timeToBeat < 0) { // The player hit BEFORE a beat
                    if (timeToBeat + calibration * 4 * beatMargin <= beatMargin) {
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
                } else { // The player hit AFTER a beat
                    if (absoluteTimeToBeat - calibration * 7 * beatMargin <= beatMargin) {
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
