using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatScript : MonoBehaviour {

    // Info about player?
    // Info about other?
    // Play sound effects randomly/at event?

	// Use this for initialization
    // Keep this for now!
	void Start () {
		
	}

    // Use Update to play random sound effects at random time intervals

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Sawblade")) {
            // Notify system of collision, perhaps via listener/callback function?
            // Also, play sound effect and give visual feedback from destruction of game object
            GameObject.Destroy(this.gameObject);
        }
    }
}
