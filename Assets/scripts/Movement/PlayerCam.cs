//Dit script zorgt ervoor dat je rond kan kijken als speler

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PWSFunctions;

public class PlayerCam : MonoBehaviour
{
    public float sensX = 1000;
    public float sensY = 1000;
    public float sprintSpeed;
    public Transform orientation;

    public float xRotation;
    public float yRotation;

    public bool MouseMoved = false;

    private void Start()
    {
        LockCursor(); //Zodat de cursor in het midden blijft
    }

    private void Update()
    {
        MoveMouse(this); //Beweeg de muis en dus playercam
        EnableSprintFOVIfNeeded(this); //Als je sprint veranderd de field of view
    }
}
