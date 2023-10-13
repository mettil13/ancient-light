using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waitToStartFinalMovement : MonoBehaviour
{

    public GameObject priest;
    public GameObject audioSource;

    private void OnTriggerEnter(Collider other) {
        priest.GetComponent<Animator>().SetBool("orbIsReady", true);
        audioSource.GetComponent<AudioSource>().enabled = true;
    }
}
