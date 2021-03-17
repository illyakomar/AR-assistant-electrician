using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerLab : MonoBehaviour
{
    public static UIManagerLab instance;

    public GameObject LabTask;
    public GameObject LabLabEquipment;
    public GameObject AllLab;
    public GameObject Ammeter;
    public GameObject Voltmeter;
    public GameObject SupportShop;
    public GameObject Source;
    public GameObject Camera;

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

    public void LabEquipment()
    {
        LabLabEquipment.SetActive(true);
        LabTask.SetActive(false);
    }

    public void LabTaskBack()
    {
        LabTask.SetActive(true);
        LabLabEquipment.SetActive(false);
    }

    public void OnAmmeter()
    {
        Camera.SetActive(true);
        Ammeter.SetActive(true);
        LabLabEquipment.SetActive(false);
        AllLab.SetActive(false);
    }

    public void OnVoltmeter()
    {
        Camera.SetActive(true);
        Voltmeter.SetActive(true);
        LabLabEquipment.SetActive(false);
        AllLab.SetActive(false);
    }

    public void OnSupportShop()
    {
        Camera.SetActive(true);
        SupportShop.SetActive(true);
        LabLabEquipment.SetActive(false);
        AllLab.SetActive(false);
    }

    public void OnSource()
    {
        Source.SetActive(true);
        Camera.SetActive(true);
        LabLabEquipment.SetActive(false);
        AllLab.SetActive(false);
    }

    public void FromAmmeter()
    {
        Ammeter.SetActive(false);
        Camera.SetActive(false);
        LabLabEquipment.SetActive(true);
        AllLab.SetActive(true);
    }

    public void FromVoltmeter()
    {
        Voltmeter.SetActive(false);
        Camera.SetActive(false);
        LabLabEquipment.SetActive(true);
        AllLab.SetActive(true);
    }

    public void FromSupportShop()
    {
        SupportShop.SetActive(false);
        Camera.SetActive(false);
        LabLabEquipment.SetActive(true);
        AllLab.SetActive(true);
    }

    public void FromSource()
    {
        Source.SetActive(false);
        Camera.SetActive(false);
        LabLabEquipment.SetActive(true);
        AllLab.SetActive(true);
    }
}
