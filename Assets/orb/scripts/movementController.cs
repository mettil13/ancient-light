using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementController : MonoBehaviour
{
    public float velocityX;
    public float velocityY;
    public float maxVelocityX;
    public float maxVelocityY;

    protected Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Horizontal") != 0) {
            if((Input.GetAxis("Horizontal") > 0 && rb.velocity.x < maxVelocityX) || (Input.GetAxis("Horizontal") < 0 && rb.velocity.x > -maxVelocityX)) {
                rb.AddForce(new Vector3(Input.GetAxis("Horizontal") * velocityX * Time.deltaTime, 0, 0));
            }
        }
        if (Input.GetAxis("Vertical") != 0) {
            if ((Input.GetAxis("Vertical") > 0 && rb.velocity.y < maxVelocityY) || (Input.GetAxis("Vertical") < 0 && rb.velocity.y > -maxVelocityY)) {
                rb.AddForce(new Vector3(0, Input.GetAxis("Vertical") * velocityY * Time.deltaTime, 0));
            }
        }
    }
}
