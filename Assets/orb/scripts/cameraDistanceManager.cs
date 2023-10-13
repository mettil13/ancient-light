using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraDistanceManager : MonoBehaviour
{
    public GameObject target;
    public float maxDistance;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Distance
        //Vector3 cameraDirection = (gameObject.transform.GetChild(0).position - gameObject.transform.position).normalized;
        Vector3 cameraDirection = (gameObject.transform.GetChild(0).position - target.transform.position).normalized;
        if(cameraDirection.z > 0) {
            cameraDirection.z = -cameraDirection.z;
        } else if(cameraDirection.z == 0) {
            cameraDirection.z = -0.001f;
        }
        Debug.DrawRay(target.transform.position, cameraDirection * maxDistance, Color.white);

        RaycastHit hit;
        if(Physics.Raycast(target.transform.position, cameraDirection, out hit, maxDistance)) { //check if there are obstacles between the center of the character and the camera
            if (!hit.collider.isTrigger) {
                gameObject.transform.GetChild(0).position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, hit.point.z - cameraDirection.z * (0.3f)); //small offset to not make the camera clip in the obstacles
                //TODO: make the offset customizable
            }
        }
        else {
            gameObject.transform.GetChild(0).position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, target.transform.position.z + cameraDirection.z * maxDistance);
        }

    }
}
