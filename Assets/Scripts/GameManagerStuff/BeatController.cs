using UnityEngine;

public class BeatController : MonoBehaviour {

    public int bpm;
    private float timeBetweenBeats;
    private float timer;
    private bool isBeating;
    private UIController ui;
    private InputReceiver receiver;

    void Awake() {
        if (bpm != 0) {
            timeBetweenBeats = 60f / bpm;
        }
    }

	void Start () {
        ui = GameObject.Find("GameUI").GetComponent<UIController>();
        if (ui == null) {
            Debug.Log("UIController was not found in BeatController.Start");
        }
        receiver = GetComponentInParent<InputReceiver>();
        StartBeat();
	}

    void LateStart() {

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
        receiver.Beat();
    }

    /// <summary>
    /// Returns the time to the closest beat - either the previous or the next one,
    /// depending on thich one is closest.
    /// </summary>
    public float TimeToBeat() {
        return Mathf.Min(timer, timeBetweenBeats - timer);
    }

    public float GetTimeBetweenBeats() {
        return timeBetweenBeats;
    }
}
