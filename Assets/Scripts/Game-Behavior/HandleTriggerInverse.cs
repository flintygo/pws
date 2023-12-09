//Dit script zorgt ervoor dat een deur open gaat als een laser de reciever raakt, alleen dan invers van definitive, dus hij 1 keer niet raakt, dan blijft hij open.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleTriggerInverse : MonoBehaviour
{
    private bool open = false;
    private float triggerDelay = 1f;

    public GameObject door;
    public float xChange;
    public float yChange;
    public float zChange;
    public float openingSpeed;
    private float phase;
    private Vector3 originalLocation;

    private void Start()
    {
        originalLocation = door.transform.position; //Slaat de originele positie van de deur op voor lineaire interpolatie
        phase = 0f;
    }

    void FixedUpdate() {
        if (triggerDelay > 0 && phase < 50){ //Kijken of hij raakt en als hij niet raakt dan openen hem definitief
            phase++;
            open = true;
        }
        else if (triggerDelay <= 0 && phase >= 50) { //Hier als hij niet raakt
            open = false;
        }

        triggerDelay -= 0.5f;
        door.transform.position = Vector3.Lerp(door.transform.position, new Vector3(xChange, yChange, zChange) * (open ? 1 : 0) + originalLocation, Time.deltaTime * openingSpeed); //Doe de deur hier definiitef dicht
    }

    public void trigger(Color laserColor)
    {
        triggerDelay = 1; //Als de laser raakt dan blijft de deur in dit geval dicht tot definitief open
    }

}