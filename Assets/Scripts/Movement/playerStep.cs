using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStep : MonoBehaviour
{
    private float bump;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        bump = other.bounds.size.y/2 + other.bounds.center.y - transform.position.y + 1f;

        if (bump < 0.4f && !other.isTrigger){
            Vector3 temp = new Vector3(0,bump,0);
            transform.parent.transform.position += temp;
        }
    }
}
