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

    public InputManager inputManager;
    
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
        if (Input.GetAxisRaw("A" + playerNumber.ToString()) != 0) {
            inputManager.playA(playerNumber);
        }
        if (Input.GetAxisRaw("E" + playerNumber.ToString()) != 0) {
            inputManager.playE(playerNumber);
        }
        if (Input.GetAxisRaw("D" + playerNumber.ToString()) != 0) {
            inputManager.playD(playerNumber);
        }
        if (Input.GetAxisRaw("G" + playerNumber.ToString()) != 0) {
            inputManager.playG(playerNumber);
        }

    }

    void receiveInputMusical(int playerNumber) {
        Debug.Log("Musical input not implemented yet");
    }
}
