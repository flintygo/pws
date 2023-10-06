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
        SceneManager.LoadScene(deathReset);
    }
}
