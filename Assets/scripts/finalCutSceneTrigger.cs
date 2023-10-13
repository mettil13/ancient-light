using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalCutSceneTrigger : MonoBehaviour {
    public GameObject levelManager;
    public GameObject orb;
    public GameObject orbForCutScene;

    private void OnTriggerEnter(Collider other) {
        levelManager.GetComponent<levelManager>().setFinalCutScene();
        levelManager.GetComponent<levelManager>().deactivateGamePlay();

        orb.SetActive(false);
        orbForCutScene.SetActive(true);
    }

}