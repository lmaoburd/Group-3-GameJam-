using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundDetection : MonoBehaviour
{
    public BoxCollider soundOverlay;
    public Rigidbody rb;
    
    bool isCrouching;
    void Start()
    {
        soundOverlay = GetComponentInChildren<BoxCollider>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.C))
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;
            soundOverlay.enabled = false;

        }
        else
        {
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
            soundOverlay.enabled = true;
        }
    }
}
