using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(ParticleSystem))]
public class CatScript : MonoBehaviour {

    public float score;
    public int playerNumber;
    public AudioClip meow1;
    public AudioClip meow2;
    public AudioClip meow3;
    public AudioClip willhelmCat;
    public AudioClip willhelmScream;
    public float willhelmChance;
    public float minMeowCooldown;
    public float maxMeowCooldown;
    private float meowTimer = 0;
    public Sprite pearSprite;
    public Sprite raspSprite;
	public Material pearDeathParticles;
	public Material raspDeathParticles;
	public GameObject particleEffectPrefab;

    // Update is called once per frame
    void Update() {
        if (meow1 != null && meow2 != null && meow3 != null) {
            if (meowTimer <= 0) {
                int meowPicker = Random.Range(0, 3);
                if (meowPicker == 0) {
                    AudioSource.PlayClipAtPoint(meow1, transform.position);
                } else if (meowPicker == 1) {
                    AudioSource.PlayClipAtPoint(meow2, transform.position);
                } else {
                    AudioSource.PlayClipAtPoint(meow3, transform.position);
                }
                meowTimer += Random.Range(minMeowCooldown, maxMeowCooldown);
            } else {
                meowTimer -= Time.deltaTime;
            }
        } else {
            Debug.Log("STÄLL IN RÄTT LJUDFILER I KATTEN!!!");
        }
    }

    public void WaveCollide () {
        GetComponent<Animator>().Play("CatWave");
    }

    public void OnDeath () {
        GameObject.Find("GameManager").GetComponent<GameManagerScript>().AddScore(playerNumber, score);
        if (playerNumber == 1) {
            GameObject obj = Instantiate(particleEffectPrefab, transform.position, transform.localRotation);
            obj.GetComponent<ParticleSystemRenderer>().material = pearDeathParticles;
            obj.GetComponent<ParticleSystem>().Play();
        } else {
            GameObject obj = Instantiate(particleEffectPrefab, transform.position, transform.localRotation);
            obj.GetComponent<ParticleSystemRenderer>().material = raspDeathParticles;
            obj.GetComponent<ParticleSystem>().Play();
        }
        if(willhelmCat != null && willhelmScream != null) {
            if(Random.Range(0f, 1f) <= willhelmChance) {
                AudioSource.PlayClipAtPoint(willhelmScream, transform.position);
            } else {
                AudioSource.PlayClipAtPoint(willhelmCat, transform.position);
            }
        } else {
            Debug.Log("AAAAAAAAH, add death scream files to cat");
        }
		Destroy(gameObject);
    }

    public void AssignPlayer(int playerNumber) {
        this.playerNumber = playerNumber;
        if (pearSprite != null && raspSprite != null) {
            SpriteRenderer renderer = GetComponent<SpriteRenderer>();
            if (playerNumber == 1) {
                renderer.sprite = pearSprite;
            } else {
                renderer.sprite = raspSprite;
            }
        } else {
            Debug.Log("STÄLL IN RÄTT SPRITE FILER PÅ KATTEN!!!");
        }
    }
}
