using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorTrigger : MonoBehaviour
{
    public GameObject door;

    bool isOpened = false;

    private Vector3 originalLocation;


    private void OnTriggerEnter(Collider other)
    {
        isOpened = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isOpened = false;
    }

    private void Start()
    {
        originalLocation = door.transform.position;
    }
    private void Update()
    {
        
        door.transform.position = Vector3.Lerp(door.transform.position, new Vector3(0, 10f, 0) * (isOpened ? 1 : 0) + originalLocation, Time.deltaTime * 5f);

        
    }
}
