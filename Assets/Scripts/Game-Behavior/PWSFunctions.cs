//Hele uitleg script: Dit script is een static class die de functions behuisd die door het pws heen kunnen worden gebruikt door hun protection level public en het feit dat het geimporteerd kan worden 
//met "using static" aan het begin van elke script aangezien het een static class is. Elke static funition in deze public static class kan dus ook worden gebruikt door het hele 
//Unity PWS project heen. Wel is het zo dat er geen variables ge-instntiate kunnen worden in deze public static class dus zul je de definites voor alle gebruikte variables kunnen vnden door 
//de objects te followen die als parameter in de functions zitten die static zijn. Hier zijn dus geen variables, alleen aanpassingen aan variables doormiddel van het feit dat we de variables 
//kunnen accessen in een ander script als die variables een protection level hebben van public, en dus doen we dat door deze te pakken als parameter voor elke function zodat we de variables 
//kunnen accessen als parameters. Hierom zul je ook zien dat wanneer er functions worden gecalled van deze static class vanuit andere scripts dat ze zichzelf als parameter gooien hiernaartoe 
//door "this" als parameter in te voeren, waardoor we hier zijn parameters die public zijn kunnen accessen.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class PWSFunctions
{
    public static void PressurePlatePushed(doorTrigger CallingDoorTrigger)
    {
        CallingDoorTrigger.collisionCount++;
    }

    public static void PressurePlateUnpushed(doorTrigger CallingDoorTrigger)
    {
        CallingDoorTrigger.collisionCount--;
    }

    public static void SetOriginalLocation(doorTrigger CallingDoorTrigger)
    {
        CallingDoorTrigger.originalLocation = CallingDoorTrigger.door.transform.position;
    }

    public static void OpenDoorIfNeeded(doorTrigger CallingDoorTrigger)
    {
        CallingDoorTrigger.isOpened = (CallingDoorTrigger.collisionCount > 0);
        CallingDoorTrigger.door.transform.position = Vector3.Lerp(CallingDoorTrigger.door.transform.position, new Vector3(CallingDoorTrigger.xChange, CallingDoorTrigger.yChange, CallingDoorTrigger.zChange) * (CallingDoorTrigger.isOpened ? 1 : 0) + CallingDoorTrigger.originalLocation, Time.deltaTime * CallingDoorTrigger.openingSpeed);
    }

    public static void OpenLevelSelectMenu(MainMenuButtons CallingMainMenuButtons)
    {
        CallingMainMenuButtons.MainSelects.SetActive(false);
        CallingMainMenuButtons.Back.SetActive(true);
        CallingMainMenuButtons.LevelSelects.SetActive(true);
    }

    public static void CloseLevelSelectMenu(MainMenuButtons CallingMainMenuButtons)
    {
        CallingMainMenuButtons.MainSelects.SetActive(true);
        CallingMainMenuButtons.Back.SetActive(false);
        CallingMainMenuButtons.LevelSelects.SetActive(false);
    }

    public static void OpenMenuIfNeeded(InPlayMenu CallingInPlayMenu)
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("MainMenu");
        }
    }

    public static void SetHandleTriggerOriginalLocation(HandleTrigger CallingHandleTrigger)
    {
        CallingHandleTrigger.originalLocation = CallingHandleTrigger.door.transform.position;
    }

    public static void SetHandleTrigger2OriginalLocation(HandleTrigger2 CallingHandleTrigger)
    {
        CallingHandleTrigger.originalLocation = CallingHandleTrigger.door.transform.position;
        CallingHandleTrigger.originalLocation1 = CallingHandleTrigger.door1.transform.position;
    }

    public static void HandleTriggerOpenDoorIfNeeded(HandleTrigger CallingHandleTrigger)
    {
        if (CallingHandleTrigger.triggerDelay > 0)
        {
            CallingHandleTrigger.open = true;
        }
        else
        {
            CallingHandleTrigger.open = false;
        }

        CallingHandleTrigger.triggerDelay -= 0.5f;
        CallingHandleTrigger.door.transform.position = Vector3.Lerp(CallingHandleTrigger.door.transform.position, new Vector3(CallingHandleTrigger.xChange, CallingHandleTrigger.yChange, CallingHandleTrigger.zChange) * (CallingHandleTrigger.open ? 1 : 0) + CallingHandleTrigger.originalLocation, Time.deltaTime * CallingHandleTrigger.openingSpeed);
    }

    public static void HandleTrigger2OpenDoorIfNeeded(HandleTrigger2 CallingHandleTrigger)
    {
        if (CallingHandleTrigger.triggerDelay > 0){
            CallingHandleTrigger.open = true;
        }
        else{
            CallingHandleTrigger.open = false;
        }

        CallingHandleTrigger.triggerDelay -= 0.5f;
        CallingHandleTrigger.door.transform.position = Vector3.Lerp(CallingHandleTrigger.door.transform.position, new Vector3(CallingHandleTrigger.xChange, CallingHandleTrigger.yChange, CallingHandleTrigger.zChange) * (CallingHandleTrigger.open ? 1 : 0) + CallingHandleTrigger.originalLocation, Time.deltaTime * CallingHandleTrigger.openingSpeed);
        CallingHandleTrigger.door1.transform.position = Vector3.Lerp(CallingHandleTrigger.door1.transform.position, new Vector3(CallingHandleTrigger.xChange1, CallingHandleTrigger.yChange1, CallingHandleTrigger.zChange1) * (CallingHandleTrigger.open ? 1 : 0) + CallingHandleTrigger.originalLocation1, Time.deltaTime * CallingHandleTrigger.openingSpeed1);
    }

    public static void OpenDoor(HandleTrigger CallingHandleTrigger)
    {
        CallingHandleTrigger.triggerDelay = 1;
    }

    public static void OpenDoor2(HandleTrigger2 CallingHandleTrigger)
    {
        CallingHandleTrigger.triggerDelay = 1;
    }

    public static void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public static void MoveMouse(PlayerCam CallingPlayerCam)
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * CallingPlayerCam.sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * CallingPlayerCam.sensY;

        CallingPlayerCam.MouseMoved = ( mouseX != 0 || mouseY != 0);

        CallingPlayerCam.yRotation += mouseX;

        CallingPlayerCam.xRotation -= mouseY;
        CallingPlayerCam.xRotation = Mathf.Clamp(CallingPlayerCam.xRotation, -90f, 90f);

        CallingPlayerCam.transform.rotation = Quaternion.Euler(CallingPlayerCam.xRotation, CallingPlayerCam.yRotation, 0);
        CallingPlayerCam.orientation.rotation = Quaternion.Euler(0, CallingPlayerCam.yRotation, 0);
    }

    public static void EnableSprintFOVIfNeeded(PlayerCam CallingPlayerCam)
    {
        CallingPlayerCam.sprintSpeed = GameObject.Find("Player").GetComponent<PlayerMovement>().sprintSpeed;
        CallingPlayerCam.GetComponent<Camera>().fieldOfView = Mathf.Lerp(CallingPlayerCam.GetComponent<Camera>().fieldOfView, 60f * (Mathf.Pow(CallingPlayerCam.sprintSpeed, 0.5f)), Time.deltaTime * 10f);
    }
}
