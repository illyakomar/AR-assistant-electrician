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
    public GameObject Step1;
    public GameObject Step2;
    public GameObject Step3;
    public GameObject SupportShop;
    public GameObject Camera;
    public GameObject Green;
    public GameObject ScanLine;
    public GameObject AmmeterObject;
    public GameObject ShopResistance;
    public GameObject VoltmeterObject;
    public GameObject EPCObject;


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
        VoltmeterObject.SetActive(false);
        EPCObject.SetActive(false);
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
}
