using UnityEngine;

/// <summary>
/// The idea is that this class will collect input from the players.
/// It checks whether each player uses musical or standard keyboard input.
/// </summary>
public class InputReceiver : MonoBehaviour {

    /*
     * These bools are used to determine wether the respective players use
     * keyboard or musical input.
     */
    public bool player1MusicalInput;
    public bool player2MusicalInput;

    private IInput inputManager = new InputManager();
    
    void Update() {
        if (inputManager != null) {
            if (!player1MusicalInput) {
                receiveInputKeyboard(1);
            } else {
                receiveInputMusical(1);
            }
            if (!player2MusicalInput) {
                receiveInputKeyboard(2);
            } else {
                receiveInputMusical(2);
            }
        } else {
            Debug.Log("inputManager is null in InputReveiver.Update()");
        }
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

    void receiveInputMusical(int playerNumber) {
        Debug.Log("Musical input not implemented yet");
    }
}
