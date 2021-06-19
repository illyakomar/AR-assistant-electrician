using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Variable : MonoBehaviour
{
    public GameObject variableWire;
    public TextMeshPro textInVoltmeter;

    public void SetWire(bool hasWire)
    {
        variableWire.SetActive(hasWire);
    }

    public void SetTextOn()
    {
        textInVoltmeter.SetText("00.85");
    }

    public void SetTextOff()
    {
        textInVoltmeter.SetText("00.00");
    }
}
