using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PusherTesting : MonoBehaviour {

    public Color green;
    public Color red;

    public InputField inputText;

    void Start() {
        inputText = GameObject.Find("InputField").GetComponent<InputField>();
    }

    public void ActivateRed() {
        PusherHandler.instance.ActivatePusher(inputText.text, red);
        inputText.text = "";
    }

    public void ActivateGreen() {
        PusherHandler.instance.ActivatePusher(inputText.text, green);
        inputText.text = "";
    }
}
