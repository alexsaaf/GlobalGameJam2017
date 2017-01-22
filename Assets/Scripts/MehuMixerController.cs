using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MehuMixerController : MonoBehaviour {

    Color colorOne;
    Color colorTwo;
    public Color colorNeutral;
    private Color lerpedColor;
    private SpriteRenderer spriteRenderer;
    private GameManagerScript gms;

    void Awake () {
        spriteRenderer = GetComponentInParent<SpriteRenderer>();
        gms = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        colorOne = gms.player1Color;
        colorTwo = gms.player2Color;
    }
	
	void Update () {
        Color one = Color.Lerp(colorOne, colorNeutral, gms.GetFillAmount(1));
        Color two = Color.Lerp(colorTwo, colorNeutral, gms.GetFillAmount(2));
        lerpedColor = Color.Lerp(one, two, 0.5f);
        spriteRenderer.color = lerpedColor;
    }
}
