using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawBladeScript : MonoBehaviour {

    public float speed;
    private Transform sawBlade;

    void Start() {
        sawBlade = (Transform)GetComponent(typeof(Transform));
    }

    void FixedUpdate () {
        sawBlade.Rotate(new Vector3(0, 0, speed * Time.fixedDeltaTime));
    }
}
