//Dit script zorgt er voor dat als je als speler tegen een hobbel die klein genoeg is dat je niet vast komt te zitten ertegenaan, maar dat je er opstapt

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStep : MonoBehaviour
{
    private float bump;

    private void OnTriggerEnter(Collider other) {
        bump = other.bounds.size.y/2 + other.bounds.center.y - transform.position.y + 1f;

        if (bump < 0.4f && !other.isTrigger){
            Vector3 temp = new Vector3(0,bump,0);
            transform.parent.transform.position += temp;
        }
    }
}
