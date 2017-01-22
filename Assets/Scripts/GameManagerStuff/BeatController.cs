using UnityEngine;

public class BeatController : MonoBehaviour {

    public int bpm;
    private float timeBetweenBeats;
    private float timer;
    private bool isBeating;
    private UIController ui;
    private InputReceiver receiver;
    public AudioClip beatClip;

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
        AudioSource.PlayClipAtPoint(beatClip, transform.position);
        ui.Beat();
        receiver.Beat();
    }

    /// <summary>
    /// Returns the time to the closest beat - either the previous or the next one,
    /// depending on thich one is closest.
    /// </summary>
    public float TimeToBeat() {
        if (timer < timeBetweenBeats / 2) {
            return timer;
        } else {
            return timer - timeBetweenBeats; // Will be a NEGATIVE number if player hits before the beat
        }
    }

    public float GetTimeBetweenBeats() {
        return timeBetweenBeats;
    }
}
