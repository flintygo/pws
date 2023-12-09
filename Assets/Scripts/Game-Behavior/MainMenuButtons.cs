//Dit script zorgt ervoor dat je in het main menu kan klikken op de knoppen, en verschillende menus in kan, zoals "Select levels"

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static PWSFunctions;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] public GameObject MainSelects;
    [SerializeField] public GameObject LevelSelects;
    [SerializeField] public GameObject Back;

    public void StartLevel(string level)
    {
        SceneManager.LoadScene(level); //Open het geklikte level
    }

    public void SelectLevels()
    {
        OpenLevelSelectMenu(this); //Opent het level select menu
    }

    public void BackSelectLevels()
    {
        CloseLevelSelectMenu(this); //Doet hem weer weg
    }

    public void ExitGame()
    {
        Application.Quit(); //Sluit de game af
    }
}
