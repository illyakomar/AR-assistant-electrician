using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerMenu : MonoBehaviour
{
    public static UIManagerMenu instance;

    public GameObject menuUI;
    public GameObject menuLabUI;
    public GameObject labUI;
    public GameObject instUI;

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

    public void InstructionUIScreen()
    {
        menuUI.SetActive(false);
        instUI.SetActive(true);
    }

    public void FromInstructionUIScreen()
    {
        menuUI.SetActive(true);
        instUI.SetActive(false);
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

    public void LinkAR()
    {
        Application.OpenURL("https://drive.google.com/drive/folders/1lv-qtC4y69hwGP7lTEHSAm_7fStBuV4I?usp=sharing");
    }

}
