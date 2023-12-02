using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public void StartLevel(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void SelectLevels(GameObject CallingGameObject)
    {
        CallingGameObject.SetActive(false);

        CallingGameObject.transform.parent.GetChild(1).gameObject.SetActive(true);
    }

    public void BackSelectLevels(GameObject CallingGameObject)
    {
        CallingGameObject.SetActive(false);

        CallingGameObject.transform.parent.GetChild(0).gameObject.SetActive(true);
    }
}
