using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettignsValueController : MonoBehaviour {

    InputField kittensPerPLayer;
    InputField litersToWin;
    Dropdown difficulty;
    GameManagerScript GMS;
    SceneHandler SH;

	// Use this for initialization
	void Start () {
        kittensPerPLayer = transform.FindChild("LitterSizeInputField").GetComponent<InputField>();
        litersToWin = transform.FindChild("LitersInputField").GetComponent<InputField>();
        difficulty = transform.FindChild("Dropdown").GetComponent<Dropdown>();
        GameObject GM = GameObject.Find("GameManager");
        GMS = GM.GetComponent<GameManagerScript>();
        SH = GM.GetComponent<SceneHandler>();
	}
	
	public void NextScene() {
        string kpp = kittensPerPLayer.text;
        string ltw = litersToWin.text;
        if (kpp.Length > 0 && ltw.Length > 0) {
            int nrOfCats = int.Parse(kpp);
            float liters = float.Parse(ltw);
            int diffi = difficulty.value;
            GMS.SetStats(liters, nrOfCats);
            SH.StartGame();
        }
    }
}
