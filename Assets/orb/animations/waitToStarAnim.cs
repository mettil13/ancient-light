using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waitToStarAnim : MonoBehaviour
{
    private float startTime;

    public float timeToWait = 15;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        gameObject.GetComponent<Animator>().SetBool("start", false);
    }

    // Update is called once per frame
    void Update()
    {
        float currentTime = Time.time;
        if(currentTime - startTime >= timeToWait) {
            gameObject.GetComponent<Animator>().SetBool("start", true);
        }
    }
}
