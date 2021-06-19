using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    public GameObject lampWire;
    public GameObject lights;

    public void SetWire(bool hasWire)
    {
        lampWire.SetActive(hasWire);
    }

    public void SetLightOn()
    {
        lights.SetActive(true);
    }

    public void SetLightOff()
    {
        lights.SetActive(false);
    }
}
