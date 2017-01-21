using UnityEngine;

public class BeatController : MonoBehaviour {

    public int bpm;
    public float timeBetweenBeats;
    private float timer;
    private bool isBeating;
    private UIController ui;

	void Start () {
        ui = GameObject.Find("GameUI").GetComponent<UIController>();
        if (ui == null) {
            Debug.Log("UIController was not found in BeatController.Start");
        }
	}
	
	void Update () {
		if (isBeating) {
            if (timer <= 0) {
                timer = timeBetweenBeats + timer;
                Beat();
            }
            timer -= Time.deltaTime;
        }
	}

    void StartBeat() {
        isBeating = true;
    }

    private void Beat() {
        // TODO: Notify the UI to blink.
        // Possibly: play beat sound effect
        ui.Beat();
    }

    /// <summary>
    /// Returns the time to the closest beat - either the previous or the next one,
    /// depending on thich one is closest.
    /// </summary>
    public float TimeToBeat() {
        return Mathf.Min(timer, timeBetweenBeats - timer);
    }
}
