using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] private GameObject MainSelects;
    [SerializeField] private GameObject LevelSelects;
    [SerializeField] private GameObject Back;

    public void StartLevel(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void SelectLevels()
    {
        MainSelects.SetActive(false);

        Back.SetActive(true);
        LevelSelects.SetActive(true);
    }

    public void BackSelectLevels()
    {
        MainSelects.SetActive(true);

        Back.SetActive(false);
        LevelSelects.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
