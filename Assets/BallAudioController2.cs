using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAudioController2 : MonoBehaviour
{
   
    //THIS IS AN ARRAY
    AudioSource[] sources;
    Rigidbody rb;
    float speed = 0.0f;
    bool isPlaying = false;


    // Start is called before the first frame update
    void Start()
    {
        sources = GetComponents<AudioSource>();
        rb = GetComponent<Rigidbody>();
        sources[1].pitch = 1.0f / rb.mass;

    }

    // Update is called once per frame
    void Update()
    {
        speed = rb.velocity.magnitude;
        if (speed > 0.1f && !isPlaying)
        {
            sources[0].Play();
        }
        else if (speed < 0.1f)
        {
            isPlaying = false;
            sources[0].Stop();
        }

        sources[0].pitch = speed / rb.mass;
    }


    // método llamada por Unity cuando chocamos con algo …
    void OnCollisionEnter(Collision collision)
    {
        print("collision");
        sources[1].Play();

    }

}