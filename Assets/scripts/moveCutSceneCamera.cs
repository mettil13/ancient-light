using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCutSceneCamera : MonoBehaviour {

    private CorneaCameraDirector Cornea;
    private GameObject corneaCameraContainer;
    private float startTime;
    private bool hasStarted = false;

    void Start() {
        //get the main Cornea script
        Cornea = GetComponent<CorneaCameraDirector>();
        corneaCameraContainer = gameObject.transform.parent.gameObject;

        startTime = Time.time; // amount of time in seconds since the project started playing, so the time at this script is started
        corneaCameraContainer.transform.position = Cornea.LerpCameraPositions[0].position;
        corneaCameraContainer.transform.rotation = Cornea.LerpCameraPositions[0].rotation;
    }

    void Update() {
        float currentTime = Time.time;

        if (!hasStarted) {
            hasStarted = true;
            Cornea.RotationLerpTime = 4000;
            Cornea.Lerp.CameraLerp(1);
        }
        else if(currentTime - startTime >= 5 && Cornea.Lerp.GetCurrentIndex == 1) {
            corneaCameraContainer.transform.position = Cornea.LerpCameraPositions[2].position;
            corneaCameraContainer.transform.rotation = Cornea.LerpCameraPositions[2].rotation;
            Cornea.LerpTime = 5000;
            Cornea.Lerp.CameraLerp(3);
        }
        else if (currentTime - startTime >= 14 && Cornea.Lerp.GetCurrentIndex == 3) {
            corneaCameraContainer.transform.position = Cornea.LerpCameraPositions[4].position;
            corneaCameraContainer.transform.rotation = Cornea.LerpCameraPositions[4].rotation;
            Cornea.Lerp.CameraLerp(5);
        }
        else if (currentTime - startTime >= 21 && Cornea.Lerp.GetCurrentIndex == 5) {
            corneaCameraContainer.transform.position = Cornea.LerpCameraPositions[6].position;
            corneaCameraContainer.transform.rotation = Cornea.LerpCameraPositions[6].rotation;
            Cornea.LerpTime = 300;
            Cornea.RotationLerpTime = 2000;
            Cornea.Lerp.CameraLerp(7);
            Cornea.Lerp.CameraLerpPath(); // 7 - 8
        }

        //Debug.Log( Cornea.Lerp.GetCurrentIndex);
    }
}
