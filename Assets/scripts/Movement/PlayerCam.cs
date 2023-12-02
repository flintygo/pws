using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX = 100;
    public float sensY = 100;
    private float sprintSpeed;
    public Transform orientation;

    float xRotation;
    float yRotation;

    void Awake () {
	    QualitySettings.vSyncCount = 0;  // VSync must be disabled
	    Application.targetFrameRate = 60;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        //get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);

        //FoV change when sprinting
        sprintSpeed = GameObject.Find("Player").GetComponent<PlayerMovement>().sprintSpeed;
        GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, 60f * (Mathf.Pow(sprintSpeed, 0.5f)), Time.deltaTime * 10f);
        
    }
}
