using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fading : MonoBehaviour {

    public Texture2D fadeOutTexture; // the texture that will overlay the screen
    public float fadeSpeed = 0.8f;

    private int drawDepth = -1000; // the texture's order in the draw hierarchy
    private float alpha = 1.0f;
    private int fadeDirection = -1; // The direction to fade; in = -1 or  out = 1

    void Start() {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

	void OnGUI() {
        //fade in/out 
        alpha += fadeDirection * fadeSpeed * Time.deltaTime;
        //force (clamp)  the number between 0 and 1
        alpha = Mathf.Clamp01(alpha);

        //set the color of the GUI
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;          // so drawgin will be on top
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture); // draws the trextrure on the whole screen
    }

    public float BeginFade(int direction) {
        fadeDirection = direction;
        return fadeSpeed; // so we can calculate the fade speed
    }

    // should be called when a level is loaded. can take the level index to only some levels will be faded
    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode) {
        BeginFade(-1);
    }
}
