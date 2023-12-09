//Dit script zorgt ervoor dat je tijdens het spelen van een level terug kan gaan naar het menu door esc te klikken

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static PWSFunctions;

public class InPlayMenu : MonoBehaviour
{
    void Update()
    {
        OpenMenuIfNeeded(this); //Opent menu als escape gedrukt is
    }
}
