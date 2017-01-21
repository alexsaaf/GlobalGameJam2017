using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour {

    private Transform sawBlade;
    public float speed;

	// Use this for initialization
	void Start () {
        sawBlade = transform;
	}

    void FixedUpdate() {
        sawBlade.Rotate(new Vector3(0, 0, speed * Time.fixedDeltaTime));
    }
}
