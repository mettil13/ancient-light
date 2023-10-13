using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleController : MonoBehaviour
{

    public GameObject[] lanterns;
    private bool isSolved = false;

    // Update is called once per frame
    void Update()
    {
        if (areAllTheLanternsOn() && !isSolved) {
            gameObject.GetComponent<Animator>().SetBool("isOpen", true);
            isSolved = true;
        }
    }

    private bool areAllTheLanternsOn() {
        foreach(GameObject i in lanterns) {
            lanternController lantern = i.GetComponent<lanternController>();
            expandedLanternController expandedLantern = i.GetComponent<expandedLanternController>();
            if (lantern == null && expandedLantern == null) {
                return false;
            }
            else if (lantern != null && !lantern.isLanternOn()) {
                return false;
            }
            else if (expandedLantern != null && !expandedLantern.isLanternOn()) {
                return false;
            }
        }
        return true;
    }

    private void OnTriggerEnter(Collider other) {
        gameObject.GetComponent<Animator>().SetBool("isOpen", false);
        gameObject.GetComponent<puzzleController>().enabled = false;
    }
}
