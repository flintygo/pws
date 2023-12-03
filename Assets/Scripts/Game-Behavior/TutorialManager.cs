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
        for (int i = 0; i < popUps.Length; i++)
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
            
            if (TimeSinceStart > 1f && PlayerCamScript.MouseMoved)
            {
                popUpIndex++;
            }

            TimeSinceStart += Time.deltaTime;
        } else if(popUpIndex == 1)
        {
            if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            {
                popUpIndex++;
            }
        } else if(popUpIndex == 2)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                popUpIndex++;
            }
        } else if(popUpIndex == 3)
        {
            if (ObjectPickupScript.CurrentObject)
            {
                popUpIndex++;
            }
        } else if(popUpIndex == 4)
        {
            if( (ObjectPickupScript.CurrentObject && Input.GetKeyDown(KeyCode.E) ) || (ObjectPickupScript.CurrentObject && Input.GetKeyDown(KeyCode.Q)))
            {
                popUpIndex++;
            }
        } else if(popUpIndex == 5)
        {
            if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
            {
                popUpIndex++;
            }
        }
    }
}
