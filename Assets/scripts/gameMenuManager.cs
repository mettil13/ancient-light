using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameMenuManager : MonoBehaviour
{

    public GameObject menu;

    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Escape")) {
            switchMenu();
        }
    }

    private void switchMenu() {
        if (menu.activeSelf) {
            menu.SetActive(false);
        } else {
            menu.SetActive(true);
        }
    }
}
