using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProrgressManager : MonoBehaviour
{
    public static ProrgressManager instance;
    public GameObject StartLab;
    public GameObject Screen1;
    public GameObject Screen2;
    public GameObject Screen3;
    public GameObject Screen4;
    public GameObject Screen5;
    public GameObject Screen6;
    public GameObject Screen7;
    public GameObject Screen8;
    public GameObject Screen9;
    public GameObject Step1;
    public GameObject Step2;
    public GameObject Step3;
    public GameObject Camera;
    public GameObject Green;
    public GameObject ScanLine;
    public GameObject WireForStep4;
    public GameObject WireForStep6;
    public GameObject WireForStep8;



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

    public void LabStart()
    {
        StartLab.SetActive(false);
        Camera.SetActive(false);
        Screen1.SetActive(true);
    }

    public void LoadScreen2()
    {
        Screen1.SetActive(false);
        Screen2.SetActive(true);
        Step1.SetActive(false);
        Step2.SetActive(true);
    }

    public void LoadScreen3()
    {
        Screen2.SetActive(false);
        Screen3.SetActive(true);
        Step2.SetActive(false);
        Step3.SetActive(true);
    }

    public void LoadScreen4()
    {
        Screen3.SetActive(false);
        Screen4.SetActive(true);
        Step3.SetActive(false);
        WireForStep4.SetActive(true);
    }

    public void LoadScreen5()
    {
        Screen4.SetActive(false);
        Screen5.SetActive(true);
    }

    public void LoadScreen6()
    {
        Screen5.SetActive(false);
        Screen6.SetActive(true);
        WireForStep4.SetActive(false);
        WireForStep6.SetActive(true);
    }

    public void LoadScreen7()
    {
        Screen6.SetActive(false);
        Screen7.SetActive(true);
    }

    public void LoadScreen8()
    {
        Screen7.SetActive(false);
        Screen8.SetActive(true);
        WireForStep6.SetActive(false);
        WireForStep8.SetActive(true);
    }

    public void LoadScreen9()
    {
        Screen8.SetActive(false);
        Screen9.SetActive(true);
    }

    public void FromScreen2()
    {
        Screen1.SetActive(true);
        Screen2.SetActive(false);
        Step1.SetActive(true);
        Step2.SetActive(false);
    }

    public void FromScreen3()
    {
        Screen2.SetActive(true);
        Screen3.SetActive(false);
        Step2.SetActive(true);
        Step3.SetActive(false);
    }

    public void FromScreen4()
    {
        Screen3.SetActive(true);
        Screen4.SetActive(false);
        Step3.SetActive(true);
    }

    public void FromScreen5()
    {
        Screen4.SetActive(true);
        Screen5.SetActive(false);
    }

    public void FromScreen6()
    {
        Screen5.SetActive(true);
        Screen6.SetActive(false);
        WireForStep4.SetActive(true);
        WireForStep6.SetActive(false);
    }

    public void FromScreen7()
    {
        Screen6.SetActive(true);
        Screen7.SetActive(false);
    }

    public void FromScreen8()
    {
        Screen7.SetActive(true);
        Screen8.SetActive(false);
        WireForStep6.SetActive(true);
        WireForStep8.SetActive(false);
    }

    public void FromScreen9()
    {
        Screen8.SetActive(true);
        Screen9.SetActive(false);
    }
}
