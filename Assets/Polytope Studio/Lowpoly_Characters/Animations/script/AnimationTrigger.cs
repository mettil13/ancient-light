using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{

    public GameObject target;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player")){
            target.GetComponent<Animator>().SetBool("isActive", false);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player")) {
            target.GetComponent<Animator>().SetBool("isActive", true);
        }
    }
}
