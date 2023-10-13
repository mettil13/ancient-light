using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelManager : MonoBehaviour
{
    public enum scene {
        InitialCutScene,
        Gameplay,
        FinalCutScene
    }

    public Camera initialCutSceneCamera;
    public GameObject initialCutSceneStage;
    public GameObject gameplayCharacter;
    public Camera gameplayCamera;
    public Camera finalCutSceneCamera;
    public GameObject finalCutSceneStage;
    public scene currentScene = scene.InitialCutScene;
    
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        if (currentScene == scene.InitialCutScene) {
            setInitialCutScene();
            deactivateGamePlay();
            deactivateFinalCutScene();
        }
        else if(currentScene == scene.Gameplay) {
            setGamePlay();
            deactivateInitialCutScene();
            deactivateFinalCutScene();
        }
        else {
            setFinalCutScene();
            deactivateInitialCutScene();
            deactivateGamePlay();
        }
    }

    // Update is called once per frame
    void Update()
    {
        float currentTime = Time.time;
        if(currentScene == scene.InitialCutScene && currentTime - startTime >= 28) {
            deactivateInitialCutScene();
            setGamePlay();
            gameplayCharacter.GetComponent<Rigidbody>().AddForce(new Vector3(500, -150, 0));
        }

        if (currentScene == scene.FinalCutScene && currentTime - startTime >= 42) {
            SceneManager.LoadScene("Credits");
        }

        // the final cutscene is activated by an external script
    }

    public void setInitialCutScene() {
        startTime = Time.time;

        currentScene = scene.InitialCutScene;
        initialCutSceneStage.SetActive(true);
        initialCutSceneCamera.enabled = true;
        initialCutSceneCamera.GetComponent<AudioListener>().enabled = true;
    }

    public void deactivateInitialCutScene() {
        initialCutSceneCamera.enabled = false;
        initialCutSceneCamera.GetComponent<AudioListener>().enabled = false;

        initialCutSceneStage.SetActive(false);
    }

    public void setGamePlay() {
        startTime = Time.time;

        currentScene = scene.Gameplay;
        gameplayCamera.enabled = true;
        gameplayCamera.GetComponent<AudioListener>().enabled = true;
        gameplayCharacter.GetComponent<movementController>().enabled = true;
    }

    public void deactivateGamePlay() {
        gameplayCamera.enabled = false;
        gameplayCamera.GetComponent<AudioListener>().enabled = false;
        gameplayCharacter.GetComponent<movementController>().enabled = false;
    }

    public void setFinalCutScene() {
        startTime = Time.time;

        currentScene = scene.FinalCutScene;
        finalCutSceneStage.SetActive(true);
        finalCutSceneCamera.enabled = true;
        finalCutSceneCamera.GetComponent<AudioListener>().enabled = true;
        finalCutSceneCamera.GetComponent<moveFinalCutSceneCamera>().enabled = true;

        StartCoroutine(AudioFadeOut(gameplayCamera.transform.gameObject, 13));
    }

    public void deactivateFinalCutScene() {
        finalCutSceneCamera.enabled = false;
        finalCutSceneCamera.GetComponent<AudioListener>().enabled = false;
        finalCutSceneCamera.GetComponent<moveFinalCutSceneCamera>().enabled = false;

        finalCutSceneStage.SetActive(false);
    }

    public scene getCurrentScene() {
        return currentScene;
    }


    public static IEnumerator AudioFadeOut(GameObject firstAudioSource, float FadeTime) {
        AudioSource audioSource = firstAudioSource.GetComponent<AudioSource>();
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0) {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
    }
}
