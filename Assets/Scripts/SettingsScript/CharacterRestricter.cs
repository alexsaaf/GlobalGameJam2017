using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class CharacterRestricter : MonoBehaviour {

    InputField ip;

	void Start () {
        ip = GetComponent<InputField>();
        ip.onValueChanged.AddListener(OnValueChange);
	}
    
    void OnValueChange(string s) {
        ip.text = Regex.Replace(s, "[^0-9]", "");
        Debug.Log("doing things");
    }	
}
