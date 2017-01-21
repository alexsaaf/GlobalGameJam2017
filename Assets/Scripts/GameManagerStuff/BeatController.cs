using UnityEngine;

public class BeatController : MonoBehaviour {

    public int bpm;
    private float timeBetweenBeats;
    private float timer;
    private bool isBeating;
    private UIController ui;

	void Start () {
        ui = GameObject.Find("GameUI").GetComponent<UIController>();
        if (ui == null) {
            Debug.Log("UIController was not found in BeatController.Start");
        } else {
            Debug.Log("UI is not null!");
        }
        if (bpm != 0) {
            Debug.Log("Set timeBetweenBeats to " + 60 / bpm);
            timeBetweenBeats = 60 / bpm;
        }
        StartBeat();
	}
	
	void Update () {
        if (timeBetweenBeats != 0) {
            if (isBeating) {
                if (timer <= 0) {
                    timer = timeBetweenBeats + timer;
                    Beat();
                }
                timer -= Time.deltaTime;
            }
        }
	}

    void StartBeat() {
        isBeating = true;
    }

    private void Beat() {
        // Possibly: play beat sound effect
        ui.Beat();
        Debug.Log("SICK BEAT, YO");
    }

    /// <summary>
    /// Returns the time to the closest beat - either the previous or the next one,
    /// depending on thich one is closest.
    /// </summary>
    public float TimeToBeat() {
        return Mathf.Min(timer, timeBetweenBeats - timer);
    }
}
