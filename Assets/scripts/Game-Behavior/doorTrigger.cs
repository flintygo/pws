//Dit script zorgt er voor dat wanneer een pressure plate wordt ingedrukt dat de deur die daarmee wordt geactiveerd ook echt geopend wordt.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PWSFunctions;

public class doorTrigger : MonoBehaviour
{
    public GameObject door;
    public bool isOpened = false;
    public float xChange;
    public float yChange;
    public float zChange;
    public float xRotationChange;
    public float yRotationChange;
    public float zRotationChange;
    public float openingSpeed;
    public int collisionCount = 0;
    public Vector3 originalLocation;

    private void OnTriggerEnter(Collider other)
    {
        PressurePlatePushed(this);
    }

    private void OnTriggerExit(Collider other)
    {
        PressurePlateUnpushed(this);
    }

    private void Start()
    {
        SetOriginalLocation(this); //Aan het begin van de game, wordt gekeken naar wat de originele locatie van de deur was om lineair te interpoleren naar de target-locatie
    }

    private void Update()
    {
        OpenDoorIfNeeded(this); //Open de deur als de pressureplate is ingedrukt
    }
}
