using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArUiManager : MonoBehaviour
{
    public static ArUiManager instance;

    public GameObject AmmeterInfo;
    public GameObject AmmeterYouTube;
    public GameObject AmmeterLink;
    public GameObject VoltmeterInfo;
    public GameObject VoltmeterYouTube;
    public GameObject VoltmeterLink;
    public GameObject SupportShopInfo;
    public GameObject SupportShopYouTube;
    public GameObject SupportShopLink;
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

    public void InfoVoltmeter()
    {
        if (!info)
        {
            VoltmeterInfo.SetActive(true);
            info = true;
        }
        else
        {
            VoltmeterInfo.SetActive(false);
            info = false;
        }
    }

    public void InfoSupportShop()
    {
        if (!info)
        {
            SupportShopInfo.SetActive(true);
            info = true;
        }
        else
        {
            SupportShopInfo.SetActive(false);
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

    public void YouTubeVoltmeter()
    {
        if (!youtube)
        {
            VoltmeterYouTube.SetActive(true);
            youtube = true;
        }
        else
        {
            VoltmeterYouTube.SetActive(false);
            youtube = false;
        }
    }

    public void YouTubeSupportShop()
    {
        if (!youtube)
        {
            SupportShopYouTube.SetActive(true);
            youtube = true;
        }
        else
        {
            SupportShopYouTube.SetActive(false);
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

    public void LinkVoltmeter()
    {
        if (!link)
        {
            VoltmeterLink.SetActive(true);
            link = true;
        }
        else
        {
            VoltmeterLink.SetActive(false);
            link = false;
        }
    }

    public void LinkSupportShop()
    {
        if (!link)
        {
            SupportShopLink.SetActive(true);
            link = true;
        }
        else
        {
            SupportShopLink.SetActive(false);
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

    public void WikipediaVoltmeter()
    {
        Application.OpenURL("https://uk.wikipedia.org/wiki/Вольтметр");
    }

    public void PortalVoltmeter()
    {
        Application.OpenURL("https://uk.845audio.org/Menggunakan-Voltmeter-5638");
    }

    public void WikipediaSupportShop()
    {
        Application.OpenURL("https://ru.wikipedia.org/wiki/Мера_электрического_сопротивления");
    }

    public void PortalSupportShop()
    {
        Application.OpenURL("http://standart-m.com.ua/elektroizmeritelnoe-oborudovanie/magaziny-soprotivleniy/magaziny-soprotivleniy-r33?mova=uk");
    }
}
