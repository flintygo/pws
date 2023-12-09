//Dit script zorgt ervoor dat een deur open gaat als een laser de reciever raakt, alleen dan voor altijd open blijft

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleTriggerDefinitive : MonoBehaviour
{
    private bool open = false;
    private float triggerDelay = 1f;

    public GameObject door;
    public float xChange;
    public float yChange;
    public float zChange;
    public float openingSpeed;
    private Vector3 originalLocation;


    // Start is called before the first frame update
    private void Start()
    {
        originalLocation = door.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate() {
        if (triggerDelay > 0){
            open = true;
        }

        triggerDelay -= 0.5f;
        door.transform.position = Vector3.Lerp(door.transform.position, new Vector3(xChange, yChange, zChange) * (open ? 1 : 0) + originalLocation, Time.deltaTime * openingSpeed);
    }

    public void trigger(Color laserColor)
    {
        triggerDelay = 1;
    }

}