using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lanternController : MonoBehaviour
{
    public Material externalMaterial;
    public Material materialOn;
    public Material materialOff;

    [SerializeField]
    private bool isOn;

    private bool hasInteracted = false;


    // Start is called before the first frame update
    void Start()
    {
        if (isOn) {
            turnOn();
        }
        else {
            turnOff();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetButton("Interact")) {
            hasInteracted = false;
        }
    }

    void OnTriggerStay(Collider collider) {
        if(collider.gameObject.layer == LayerMask.NameToLayer("Player")) {
            if (Input.GetButton("Interact") && !hasInteracted) {
                if (isOn) {
                    turnOff();
                } else {
                    turnOn();
                }
                
                hasInteracted = true;
            }
        }
    }

    public bool isLanternOn() {
        return isOn;
    }

    public void turnOn() {
        Material[] mat = new Material[2];
        mat[0] = externalMaterial;
        mat[1] = materialOn;
        gameObject.GetComponent<MeshRenderer>().materials = mat;
        gameObject.GetComponent<Light>().enabled = true;

        isOn = true;
    }

    public void turnOff() {
        Material[] mat = new Material[2];
        mat[0] = externalMaterial;
        mat[1] = materialOff;
        gameObject.GetComponent<MeshRenderer>().materials = mat;
        gameObject.GetComponent<Light>().enabled = false;

        isOn = false;
    }

    public void switchLantern() {
        if (isOn) {
            turnOff();
        }
        else {
            turnOn();
        }
    }
}
