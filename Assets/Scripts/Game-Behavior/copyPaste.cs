using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class copyPaste : MonoBehaviour
{
    public GameObject parcour;

    private void Start()
    {
        parcour = Resources.Load("parcour") as GameObject;
    }

    void SpawnObject ()
    {
        Instantiate(parcour);
    }
}
