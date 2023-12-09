//Dit script zorgt ervoor dat de playercamera en de player dezelfde locatie hebben

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform camerPosition;
   
    private void Update()
    {
        transform.position = camerPosition.position;
    }
}
