using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleTrigger : MonoBehaviour
{
    private bool open = false;
    private bool previousTrigger = false;

    // Start is called before the first frame update
    void Start()
    {

    }
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void trigger(Color laserColor)
    {
        Debug.Log("Triggered!");
        previousTrigger = true;

    }
}
