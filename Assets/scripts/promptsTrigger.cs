using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class promptsTrigger : MonoBehaviour
{
    public GameObject prompt;
    public GameObject levelManager;

    void Start()
    {
        prompt.SetActive(false);
    }

    private void OnTriggerEnter(Collider other) {
        if(levelManager.GetComponent<levelManager>().getCurrentScene() == global::levelManager.scene.Gameplay) {
            prompt.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other) {
        prompt.SetActive(false);
    }
}
