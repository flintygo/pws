using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    Vector3 lastMouseCoordinate = Vector3.zero;

    public GameObject[] popUps;
    private int popUpIndex;

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
            
            if (Input.mousePosition != lastMouseCoordinate)
            {
                popUpIndex++;
            }

            lastMouseCoordinate = Input.mousePosition;
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
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                popUpIndex++;
            }
        } else if(popUpIndex == 4)
        {
            if(Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Q))
            {
                popUpIndex++;
            }
        } else if(popUpIndex == 5)
        {
            if(Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.LeftShift))
            {
                popUpIndex++;
            }
        }
    }
}
