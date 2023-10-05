using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleTrigger : MonoBehaviour
{
    private bool open = false;
    private float triggerDelay = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    

    // Update is called once per frame
    void Update()
    {
        triggerDelay -= 0.5f;
        Debug.Log(open);
    }

    void FixedUpdate() {
        if (triggerDelay > 0){
            open = true;
        }
        else{
            open = false;
        }

        //hier de line om die deur te openen van de andere trigger script
    }

    public void trigger(Color laserColor)
    {
        Debug.Log("Triggered!");
        triggerDelay = 1f;

    }
}
