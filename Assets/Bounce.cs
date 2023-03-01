using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public AudioSource bounce;

    // Start is called before the first frame update
    void Start()
    {
        // GetComponent<AudioSource> ().playOnAwake = false;
        bounce = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter (Collision collision)
    {
        // Debug.Log("bounce");
        bounce.Play();
    }
}
