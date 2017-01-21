using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Pusher : MonoBehaviour {

    public GameObject wavePrefab;

    public Color activatedColor;
    public float activatedTime;

    public string identity;

    Color standardColor;

    SpriteRenderer sr;

    void Awake() {
        identity = new string(identity.OrderBy(c => c).ToArray()).ToUpper();
    }

    void Start () {
        sr = GetComponent<SpriteRenderer>();
        standardColor = sr.color;
	}

    public void ActivateIdentity(string idToActivate, Color playerColor) {

        if(idToActivate.Equals(identity)) {
            activatedColor = playerColor;
            Activate();
        }
    }

    public void Activate() {
        StartCoroutine("ActivateIndication");
        BoxCollider2D bc2d = wavePrefab.GetComponent<BoxCollider2D>();
        Vector3 pos = transform.position + transform.up * (sr.bounds.size.y + bc2d.bounds.size.y);
        Instantiate(wavePrefab, pos, transform.localRotation);
    }

    IEnumerator ActivateIndication() {
        sr.color = activatedColor;
        yield return new WaitForSeconds(activatedTime);
        sr.color = standardColor;
    }
}
