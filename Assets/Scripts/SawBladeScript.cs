using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawBladeScript : MonoBehaviour {

    public float speed;
    private Transform sawBlade;
    public string catTag = "Cat";
    public AudioClip slaughterAudio;

    void Start() {
        sawBlade = (Transform)GetComponent(typeof(Transform));
    }

    void FixedUpdate () {
        sawBlade.Rotate(new Vector3(0, 0, speed * Time.fixedDeltaTime));
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag(catTag)) {
            other.GetComponent<CatScript>().OnDeath();
            AudioSource.PlayClipAtPoint(slaughterAudio, sawBlade.position);
            // Also, play sound effect and give visual feedback (Saw)

        }
    }
}
