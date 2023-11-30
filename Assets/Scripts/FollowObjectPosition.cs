using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObjectPosition : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject PlayerThing;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = PlayerThing.transform.position;
    }
}
