using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndIt : MonoBehaviour {

    SceneHandler SH;

    void Start() {
        SH = GameObject.Find("GameManager").GetComponent<SceneHandler>();
    }

    public void MainMenu() {
        SH.LoadMainMenu();
    }

	public void TheEnd() {
        Application.Quit();
    }
}
