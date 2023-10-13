using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public GameObject target;
    public int portionOfScreenToStartMoving;
    public float delay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 screenPos = gameObject.GetComponentInChildren<Camera>().WorldToScreenPoint(target.transform.position);
        float screenHeight = Screen.height;
        float cameraY = gameObject.transform.position.y;

        if ((screenPos.y * 100) / screenHeight < portionOfScreenToStartMoving) {
            cameraY = gameObject.GetComponentInChildren<Camera>().ScreenToWorldPoint(new Vector3(0, portionOfScreenToStartMoving * screenHeight / 100, target.transform.position.z)).y;
        }
        if ((screenPos.y * 100) / screenHeight > (100 - portionOfScreenToStartMoving)) {
            cameraY = gameObject.GetComponentInChildren<Camera>().ScreenToWorldPoint(new Vector3(0, (100 - portionOfScreenToStartMoving) * screenHeight / 100, target.transform.position.z)).y;
        }

        Vector3 velocity = Vector3.zero;
        gameObject.transform.position = Vector3.SmoothDamp(gameObject.transform.position, new Vector3(target.transform.position.x, cameraY, target.transform.position.z), ref velocity, delay);
        //gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(target.transform.position.x, cameraY, target.transform.position.z), delay * Time.deltaTime);
    }
}
