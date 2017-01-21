using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour {

    private Fading fading;

	// Use this for initialization
	void Start () {
        SceneHandler.DontDestroyOnLoad(gameObject);
        fading = GetComponent<Fading>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadMainMenu() {
        StartCoroutine("MainSceneLoadFading");
    }

    public void LoadEndScene() {
        StartCoroutine("EndSceneLoadFading");
    }

    public void LoadNextScene() {
        Debug.Log("FUCK YOU I AM A SCENELOADER");
        StartCoroutine("NextScene");
    }

    IEnumerator MainSceneLoadFading() {
        float fadeTime = fading.BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadSceneAsync("MainMenu");
    }

    IEnumerator EndSceneLoadFading() {
        float fadeTime = fading.BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadSceneAsync("EndScene");
    }

    IEnumerator NextScene() {
        float fadeTime = fading.BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
