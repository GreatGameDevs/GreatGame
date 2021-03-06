﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CreatorKitCode;

public class PresentScript : MonoBehaviour
{

    public GameObject pickupSpot;
    public Canvas canvas;

    public AudioClip[] PresentSFXClips;
    public SFXManager.Use UseType;

    public string deliverTo;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Probably find and assign pickupSpot gameobject here
        // so we don't have to drag it in for every present
    }

    void Update()
    {
        
    }

    public Canvas getRiddleCanvas(){
        return canvas;
    }

    public string getDeliverInfo(){
        return deliverTo;
    }

    public void pickup() {
        Debug.Log("pickup function called");
        rb.useGravity = false;
        this.transform.position = pickupSpot.transform.position;
        this.transform.parent = pickupSpot.transform;

        //Instruct SFX manager to play sound at location of the transform this script is attached to (the present)
        SFXManager.PlaySound(UseType, new SFXManager.PlayData()
        {
            Clip = PresentSFXClips[0],
            Position = transform.position
        });
    }

    public void drop() {
        Debug.Log("Drop function called");
        this.transform.parent = null;
        rb.constraints &= ~RigidbodyConstraints.FreezePositionY;
        rb.useGravity = true;

        SFXManager.PlaySound(UseType, new SFXManager.PlayData()
        {
            Clip = PresentSFXClips[1],
            Position = transform.position
        });


    }


}
