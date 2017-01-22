using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    // Sorted on difficulty, easiest first!
    public AudioClip[] bpms;
    private AudioSource selectedBpm;
    private bool paused = false;

    void SetSelectedBpm (int bpmLevel) {
        if (selectedBpm != null) {
            selectedBpm.Stop();
        }
        selectedBpm.clip = bpms[bpmLevel];
        selectedBpm.loop = true;
    }

    public void SetEasy () {
        SetSelectedBpm(0);
    }

    public void SetNormal() {
        SetSelectedBpm(1);
    }

    public void SetHard() {
        SetSelectedBpm(2);
    }

    public void Play() {
        selectedBpm.Play();
    }

    public void Stop() {
        selectedBpm.Stop();
    }

    public void TogglePause() {
        if (paused) {
            selectedBpm.UnPause();
        } else {
            selectedBpm.Pause();
        }
        paused = !paused;
    }
}
