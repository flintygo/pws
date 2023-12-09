//Dit script zorgt ervoor dat een deur open gaat als een laser de reciever raakt, alleen dan met 2 deuren

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleTrigger2 : MonoBehaviour
{
    public bool open = false;
    public float triggerDelay = 1f;

    public GameObject door;
    public float xChange;
    public float yChange;
    public float zChange;
    public float openingSpeed;
    public Vector3 originalLocation;

    public GameObject door1;
    public float xChange1;
    public float yChange1;
    public float zChange1;
    public float openingSpeed1;
    public Vector3 originalLocation1;

    private void Start()
    {
        SetHandleTrigger2OriginalLocation(this); //Zet de originele locaties van de deuren voor lineaire interpolatie
    }

    void FixedUpdate() 
    {
        HandleTrigger2OpenDoorIfNeeded(this);  //Verander locatie als geopent
    }

    public void trigger(Color laserColor)
    {
        OpenDoor(this); //Open de deur wanneer de laser de trigger raakt
    }

}