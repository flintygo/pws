//Dit script zorgt ervoor dat in level 1 een tutorial wordt gedisplayed in de vorm van pop-up tekst op het scherm

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    Vector3 lastMouseCoordinate = Vector3.zero;
    [SerializeField] private  ObjectPickup ObjectPickupScript;
    [SerializeField] private  PlayerCam PlayerCamScript;
    public GameObject[] popUps;
    public int popUpIndex;
    private float TimeSinceStart = 0;

    private void Update()
    {
        for (int i = 0; i < popUps.Length; i++) //Loopt door de lijst van popups heen en displayed degene die nu actief is, als je klaar bent met de tutorial wordt er niks gedisplayed
        {
            if(i == popUpIndex)
            {
                popUps[i].SetActive(true);
            }
            else
            {
                popUps[i].SetActive(false);
            }
        }
        
        if(popUpIndex == 0) 
        {
            
            if (TimeSinceStart > 1f && PlayerCamScript.MouseMoved) //Als de muis bewogen is, ga door naar de volgende popup
            {
                popUpIndex++;
            }

            TimeSinceStart += Time.deltaTime;
        } else if(popUpIndex == 1)
        {
            if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)) //Als de player bewogen is, ga door naar de volgende popup
            {
                popUpIndex++;
            }
        } else if(popUpIndex == 2)
        {
            if (Input.GetKeyDown(KeyCode.Space)) //Als spatie is ingedrukt, ga door naar de volgende popup
            {
                popUpIndex++;
            }
        } else if(popUpIndex == 3)
        {
            if (ObjectPickupScript.CurrentObject) //Als er een obejct is opgepakt, ga door naar de volgende popup
            {
                popUpIndex++;
            }
        } else if(popUpIndex == 4)
        {
            if( (ObjectPickupScript.CurrentObject && Input.GetKeyDown(KeyCode.E) ) || (ObjectPickupScript.CurrentObject && Input.GetKeyDown(KeyCode.Q))) // Als het object is gedraait, ga door naar de volgende popup
            {
                popUpIndex++;
            }
        } else if(popUpIndex == 5)
        {
            if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift)) //Als er is gesprint, ga door naar de volgende popup
            {
                popUpIndex++;
            }
        }
    }
}
