//Dit script zorgt ervoor dat een deur open gaat als een laser de reciever raakt

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PWSFunctions;

public class HandleTrigger : MonoBehaviour
{
    public bool open = false;
    public float triggerDelay = 1f;
    public GameObject door;
    public float xChange;
    public float yChange;
    public float zChange;
    public float openingSpeed;
    public Vector3 originalLocation;

    private void Start()
    {
        SetHandleTriggerOriginalLocation(this); //Het slaat de originele locatie van de deur op
    }

    void FixedUpdate() 
    {
        HandleTriggerOpenDoorIfNeeded(this); //Verander locatie als geopent
    }

    public void trigger(Color laserColor)
    {
        OpenDoor(this); //Open de deur wanneer de laser de trigger raakt
    }

}