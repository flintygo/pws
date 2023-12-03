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


    // Start is called before the first frame update
    private void Start()
    {
        originalLocation = door.transform.position;
        phase = 0f;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate() {
        if (triggerDelay > 0 && phase < 10){
            phase++;
            open = true;
        }
        else if (triggerDelay <= 0 && phase >= 10) {
            open = false;
        }

        triggerDelay -= 0.5f;
        door.transform.position = Vector3.Lerp(door.transform.position, new Vector3(xChange, yChange, zChange) * (open ? 1 : 0) + originalLocation, Time.deltaTime * openingSpeed);
    }

    public void trigger(Color laserColor)
    {
        triggerDelay = 1;
    }

}