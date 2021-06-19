using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    public GameObject batteryWire;

    public void SetWire(bool hasWire)
    {
        batteryWire.SetActive(hasWire);
    }
}
