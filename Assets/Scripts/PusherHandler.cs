using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PusherHandler : MonoBehaviour {

    public static PusherHandler instance;

    List<Pusher> pushers;

    void Start() {
        //Singleton
        if(instance == null) {
            DontDestroyOnLoad(gameObject);
            instance = this;
        } else {
            Destroy(this);
        }

        pushers = new List<Pusher>();

        //Find all the pushers
        foreach(Transform child in transform) {
            Pusher pusher = child.gameObject.GetComponent<Pusher>();
            if(pusher != null) {
                pushers.Add(pusher);
            }
        }
    }

    public void ActivatePusher(string id, Color playerColor) {
        string sortedID = new string(id.OrderBy(c => c).ToArray()).ToUpper();
        
        foreach(Pusher pusher in pushers) {
            pusher.ActivateIdentity(sortedID, playerColor);
        }
    }
}
