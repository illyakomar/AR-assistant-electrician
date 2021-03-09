using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerLab : MonoBehaviour
{
    public static UIManagerLab instance;

    public GameObject LabTask;
    public GameObject LabLabEquipment;
    public GameObject AllLab;
    public GameObject Ammert;

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

    public void Ammeter()
    {
        Ammert.SetActive(true);
        LabLabEquipment.SetActive(false);
        AllLab.SetActive(false);
    }

   
}
