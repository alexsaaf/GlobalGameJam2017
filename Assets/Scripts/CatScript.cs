using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatScript : MonoBehaviour {

    public int playerNumber;
	
	// Update is called once per frame
	void Update () {
	}

    public void OnDeath () {
        //GameManager.registerDeathThing
        GameObject.Destroy(gameObject);
    }
}
