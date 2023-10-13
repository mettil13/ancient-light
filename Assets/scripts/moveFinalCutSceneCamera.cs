using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveFinalCutSceneCamera : MonoBehaviour
{
    private CorneaCameraDirector Cornea;
    private GameObject corneaCameraContainer;
    private float startTime;
    private bool hasStarted = false;

    void OnEnable() {
        startTime = Time.time; // amount of time in seconds since this script started playing

        //get the main Cornea script
        Cornea = GetComponent<CorneaCameraDirector>();
        corneaCameraContainer = gameObject.transform.parent.gameObject;

        corneaCameraContainer.transform.position = Cornea.LerpCameraPositions[0].position;
        corneaCameraContainer.transform.rotation = Cornea.LerpCameraPositions[0].rotation;

        
    }

    void Update()
    {
        float currentTime = Time.time;
        
        if (!hasStarted) {
            Cornea.LerpTime = 2500;
            Cornea.RotationLerpTime = 2000;
            Cornea.Lerp.CameraLerp(1);
            hasStarted = true;
        } else if (currentTime - startTime >= 10 && Cornea.Lerp.GetCurrentIndex == 1) {
            Cornea.Lerp.CameraLerp(2);
        } else if (currentTime - startTime >= 20 && Cornea.Lerp.GetCurrentIndex == 2) {
            Cornea.Lerp.CameraLerp(3);
        }


        //Debug.Log(Cornea.Lerp.GetCurrentIndex);
    }
}
