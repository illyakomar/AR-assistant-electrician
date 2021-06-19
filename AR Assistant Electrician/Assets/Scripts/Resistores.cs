using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resistores : MonoBehaviour
{
    public GameObject resistoresWire;

    public void SetWire(bool hasWire)
    {
        resistoresWire.SetActive(hasWire);
    }
}
