using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArUiManager : MonoBehaviour
{
    public static ArUiManager instance;

    public GameObject AmmeterInfo;
    public GameObject AmmeterYouTube;
    public GameObject AmmeterLink;
    public bool info;
    public bool youtube;
    public bool link;

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

    public void Info()
    {
        if (!info)
        {
            AmmeterInfo.SetActive(true);
            info = true;
        }
        else
        {
            AmmeterInfo.SetActive(false);
            info = false;
        }
    }

    public void YouTube()
    {
        if (!youtube)
        {
            AmmeterYouTube.SetActive(true);
            youtube = true;
        }
        else
        {
            AmmeterYouTube.SetActive(false);
            youtube = false;
        }
    }

    public void Link()
    {
        if (!link)
        {
            AmmeterLink.SetActive(true);
            link = true;
        }
        else
        {
            AmmeterLink.SetActive(false);
            link = false;
        }
    }

    public void Wikipedia()
    {
        Application.OpenURL("https://uk.wikipedia.org/wiki/Амперметр");
    }

    public void Portal()
    {
        Application.OpenURL("https://uk.mosg-portal.com/an-ammeter-work-4963680-463");
    }
}
