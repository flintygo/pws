using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InPlayMenu : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("MainMenu");
        }
    }
}
