using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorTrigger : MonoBehaviour
{
    public GameObject door;

    bool isOpened = false;

    public float xChange;
    public float yChange;
    public float zChange;
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
        
        door.transform.position = Vector3.Lerp(door.transform.position, new Vector3(xChange, yChange, zChange) * (isOpened ? 1 : 0) + originalLocation, Time.deltaTime * 5f);

        
    }
}
