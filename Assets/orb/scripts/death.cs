using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death : MonoBehaviour
{

    public GameObject startCheckpoint;
    private GameObject lastCheckpoint;

    private void Start() {
        if(startCheckpoint != null) {
            gameObject.transform.position = startCheckpoint.transform.position;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Checkpoints")) {
            lastCheckpoint = other.transform.gameObject;
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemies")) {
            playDeath();
        }
    }

    private void playDeath() {
        if(lastCheckpoint != null) {
            gameObject.GetComponent<movementController>().enabled = false;
            gameObject.GetComponent<TrailRenderer>().enabled = false;
            gameObject.GetComponent<Animator>().SetTrigger("death");
            StartCoroutine(DeathCoroutine());
        }
    }

    IEnumerator DeathCoroutine() {
        yield return new WaitForSeconds(1.5f);
        gameObject.transform.position = lastCheckpoint.transform.position;
        gameObject.GetComponent<movementController>().enabled = true;
        gameObject.GetComponent<TrailRenderer>().enabled = true;
    }
}
