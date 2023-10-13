using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeSkyBox : MonoBehaviour
{

    public Material newSkybox;

    private void OnTriggerEnter(Collider other) {
        RenderSettings.skybox = newSkybox;
        DynamicGI.UpdateEnvironment();
    }
}
