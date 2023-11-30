using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleTrigger2 : MonoBehaviour
{
    private bool open = false;
    private float triggerDelay = 1f;

    public GameObject door;
    public float xChange;
    public float yChange;
    public float zChange;
    public float openingSpeed;
    private Vector3 originalLocation;

    public GameObject door1;
    public float xChange1;
    public float yChange1;
    public float zChange1;
    public float openingSpeed1;
    private Vector3 originalLocation1;


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
        else{
            open = false;
        }

        triggerDelay -= 0.5f;
        door.transform.position = Vector3.Lerp(door.transform.position, new Vector3(xChange, yChange, zChange) * (open ? 1 : 0) + originalLocation, Time.deltaTime * openingSpeed);
        door1.transform.position = Vector3.Lerp(door1.transform.position, new Vector3(xChange1, yChange1, zChange1) * (open ? 1 : 0) + originalLocation1, Time.deltaTime * openingSpeed1);
    }

    public void trigger(Color laserColor)
    {
        triggerDelay = 1;
    }

}