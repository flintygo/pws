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
    public float xRotationChange;
    public float yRotationChange;
    public float zRotationChange;
    public float openingSpeed;
    private int collisionCount = 0;
    private Vector3 originalLocation;
    private float originalRotationX;
    private float originalRotationY;
    private float originalRotationZ;


    private void OnTriggerEnter(Collider other)
    {
        collisionCount++;
    }

    private void OnTriggerExit(Collider other)
    {
        collisionCount--;
    }

    private void Start()
    {
        originalLocation = door.transform.position;
        originalRotationX = door.transform.rotation.x;
        originalRotationY = door.transform.rotation.y;
        originalRotationZ = door.transform.rotation.z;
    }

    private void Update()
    {
        isOpened = (collisionCount > 0);
        door.transform.position = Vector3.Lerp(door.transform.position, new Vector3(xChange, yChange, zChange) * (isOpened ? 1 : 0) + originalLocation, Time.deltaTime * openingSpeed);
        transform.localRotation = Quaternion.Euler(originalRotationX,  originalRotationY + 180 * (isOpened ? 1 : 0), originalRotationZ);

        
    }
}
