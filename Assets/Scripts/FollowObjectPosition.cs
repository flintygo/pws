//Dit script zorgt ervoor dat een object de speler volgt (dezelfde positie aanneemt)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObjectPosition : MonoBehaviour
{
    [SerializeField] private GameObject PlayerThing;

    void Update()
    {
        transform.position = PlayerThing.transform.position; //Zet positie van het object war deze script op staat gelijk aan de positie van de speler
    }
}
