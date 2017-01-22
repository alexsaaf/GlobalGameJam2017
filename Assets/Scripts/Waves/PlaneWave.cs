using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneWave : MonoBehaviour {

    // The speed of the wave in the up driection relative to the transfrom.
    public float speed = 4;
    // The force applied to the encountered object will be a factor times the speed of the wave.
    public float forceMultiplier = 30f;

    // The tag of the object to destroy this wave.
    public string destroyTag = "Wall";

    // The tag of the object to add a force when encountered. 
    public string addForceTag = "Cat";

    private HashSet<Transform> encounteredCats = new HashSet<Transform>();

	// Update is called once per frame
	void Update () {
        transform.Translate(transform.up * speed* Time.deltaTime, Space.World);
	}

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == destroyTag) {
            Destroy(gameObject);
        }
        if (other.tag == addForceTag && !encounteredCats.Contains(other.transform)) {
            Rigidbody2D body = other.GetComponent<Rigidbody2D>();
            if (body != null) {
                other.gameObject.GetComponent<CatScript>().WaveCollide();
                body.AddForce(transform.up * speed * forceMultiplier);
                encounteredCats.Add(other.transform);
            }
        }
    }
}
