using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour {

    private Fading fading;
    private GameManagerScript GMS;

	// Use this for initialization
	void Start () {
        SceneHandler.DontDestroyOnLoad(gameObject);
        GMS = GetComponent<GameManagerScript>();
        fading = GetComponent<Fading>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadMainMenu() {
        SetupGMS();
        StartCoroutine("MainSceneLoadFading");
    }

    public void LoadEndScene() {
        SetupGMS();
        StartCoroutine("EndSceneLoadFading");
    }

    public void LoadNextScene() {
        SetupGMS();
        StartCoroutine("NextScene");
    }

    public void StartGame() {
        GMS.gameStarting = true;
        GMS.ResetStats();
        StartCoroutine("FirstLevelLoadFading");
    }

    void SetupGMS() {
        GMS.gameStarting = false;
        GMS.spawnCats = false;
    }

    IEnumerator FirstLevelLoadFading() {
        float fadeTime = fading.BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadSceneAsync("FirstLevel");
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
