//Dit script zorgt er voor dat als je het lava inspringt dat het level wordt gereset

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathBox : MonoBehaviour
{
    [SerializeField]
    private string deathReset;

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(deathReset); //Als je de collider aanraakt wordt je naar de deathReset scene gestuurd
    }
}
