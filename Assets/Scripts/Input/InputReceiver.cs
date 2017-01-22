using UnityEngine;

/// <summary>
/// The idea is that this class will collect input from the players.
/// It checks whether each player uses musical or standard keyboard input.
/// </summary>
public class InputReceiver : MonoBehaviour {

    /*
     * These bools are used to determine wether the respective players use
     * keyboard or controller.
     */
    public bool player1Controller;
    public bool player2Controller;

    public UIController ui;

    private InputManager inputManager;
    
    void Start() {
        inputManager = new InputManager(ui, GetComponentInParent<BeatController>());
    }
    
    void Update() {
        if (inputManager != null) {
            if (!player1Controller) {
                receiveInputKeyboard(1);
            } else {
                receiveInputController(1);
            }
            if (!player2Controller) {
                receiveInputKeyboard(2);
            } else {
                receiveInputController(2);
            }
        } else {
            Debug.Log("inputManager is null in InputReceiver.Update()");
        }
        inputManager.Update();
    }

    void receiveInputKeyboard(int playerNumber) {
        if (Input.GetButtonDown("A" + playerNumber.ToString())) {
            inputManager.playA(playerNumber);
        }
        if (Input.GetButtonDown("E" + playerNumber.ToString())) {
            inputManager.playE(playerNumber);
        }
        if (Input.GetButtonDown("D" + playerNumber.ToString())) {
            inputManager.playD(playerNumber);
        }
        if (Input.GetButtonDown("G" + playerNumber.ToString())) {
            inputManager.playG(playerNumber);
        }
    }

    void receiveInputController(int playerNumber) {
        Debug.Log("Controller input not implemented yet");
    }

    public void Beat() {
        inputManager.Beat();
    }
}
