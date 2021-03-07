using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerMenu : MonoBehaviour
{
    public static UIManagerMenu instance;

    public GameObject menuUI;
    public GameObject menuLabUI;
    public GameObject labUI;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

    public void MenuScreen()
    {
        menuUI.SetActive(true);
        menuLabUI.SetActive(false);
    }

    public void MenuLabUIScreen()
    {
        menuUI.SetActive(false);
        menuLabUI.SetActive(true);
    }

    public void LabUIScreen()
    {
        menuLabUI.SetActive(false);
        labUI.SetActive(true);
    }

    public void BackMenuLabUIScreen()
    {
        labUI.SetActive(false);
        menuLabUI.SetActive(true);
    }
}
