using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleTrigger : MonoBehaviour
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
        triggerDelay -= 0.5f;
        Debug.Log(open);
        door.transform.position = Vector3.Lerp(door.transform.position, new Vector3(xChange, yChange, zChange) * (open ? 1 : 0) + originalLocation, Time.deltaTime * openingSpeed);
    }

    void FixedUpdate() {
        if (triggerDelay > 0){
            open = true;
        }
        else{
            open = false;
        }

        if (open == true) {

        }
    }

    public void trigger(Color laserColor)
    {
        
    }

}