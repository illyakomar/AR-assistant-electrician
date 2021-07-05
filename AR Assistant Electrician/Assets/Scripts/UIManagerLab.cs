using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagerLab : MonoBehaviour
{
    public static UIManagerLab instance;

    [Header("Screens")]
    public GameObject lab;
    public GameObject labTask;
    public GameObject labEquipment;

    [Header("Information Screens")]
    public GameObject ammeter;
    public GameObject voltmeter;
    public GameObject supportShop;
    public GameObject source;

    [Header("AR Camera")]
    public GameObject camera;
    public GameObject greenTriangle;
    public GameObject redTriangle;

    [Header("Target")]
    public GameObject ammeterInfo;
    public GameObject ammeterYouTube;
    public GameObject ammeterLink;
    public GameObject voltmeterInfo;
    public GameObject voltmeterYouTube;
    public GameObject voltmeterLink;
    public GameObject supportShopInfo;
    public GameObject supportShopYouTube;
    public GameObject supportShopLink;
    public GameObject batteryInfo;
    public GameObject batteryYouTube;
    public GameObject batteryLink;


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

    public void LabEquipment()
    {
        labEquipment.SetActive(true);
        labTask.SetActive(false);
    }

    public void LabTaskBack()
    {
        labTask.SetActive(true);
        labEquipment.SetActive(false);
    }

    public void OnAmmeter()
    {
        camera.SetActive(true);
        ammeter.SetActive(true);
        labEquipment.SetActive(false);
        lab.SetActive(false);
        greenTriangle.SetActive(true);
        redTriangle.SetActive(true);
    }

    public void OnVoltmeter()
    {
        camera.SetActive(true);
        voltmeter.SetActive(true);
        labEquipment.SetActive(false);
        lab.SetActive(false);
        greenTriangle.SetActive(true);
        redTriangle.SetActive(true);
    }

    public void OnSupportShop()
    {
        camera.SetActive(true);
        supportShop.SetActive(true);
        labEquipment.SetActive(false);
        lab.SetActive(false);
        greenTriangle.SetActive(true);
        redTriangle.SetActive(true);
    }

    public void OnSource()
    {
        source.SetActive(true);
        camera.SetActive(true);
        labEquipment.SetActive(false);
        lab.SetActive(false);
        greenTriangle.SetActive(true);
        redTriangle.SetActive(true);
    }

    public void FromAmmeter()
    {
        ammeter.SetActive(false);
        camera.SetActive(false);
        labEquipment.SetActive(true);
        lab.SetActive(true);
        info = false;
        youtube = false;
        link = false;
        greenTriangle.SetActive(false);
        redTriangle.SetActive(false);
        ammeterInfo.SetActive(false);
        ammeterYouTube.SetActive(false);
        ammeterLink.SetActive(false);
    }

    public void FromVoltmeter()
    {
        voltmeter.SetActive(false);
        camera.SetActive(false);
        labEquipment.SetActive(true);
        lab.SetActive(true);
        info = false;
        youtube = false;
        link = false;
        greenTriangle.SetActive(false);
        redTriangle.SetActive(false);
        voltmeterInfo.SetActive(false);
        voltmeterYouTube.SetActive(false);
        voltmeterLink.SetActive(false);
    }

    public void FromSupportShop()
    {
        supportShop.SetActive(false);
        camera.SetActive(false);
        labEquipment.SetActive(true);
        lab.SetActive(true);
        info = false;
        youtube = false;
        link = false;
        greenTriangle.SetActive(false);
        redTriangle.SetActive(false);
        supportShopInfo.SetActive(false);
        supportShopYouTube.SetActive(false);
        supportShopLink.SetActive(false);
    }

    public void FromSource()
    {
        source.SetActive(false);
        camera.SetActive(false);
        labEquipment.SetActive(true);
        lab.SetActive(true);
        info = false;
        youtube = false;
        link = false;
        greenTriangle.SetActive(false);
        redTriangle.SetActive(false);
        batteryInfo.SetActive(false);
        batteryYouTube.SetActive(false);
        batteryLink.SetActive(false);
    }

    public void InfoAmmeter()
    {
        if (!info)
        {
            ammeterInfo.SetActive(true);
            info = true;
        }
        else
        {
            ammeterInfo.SetActive(false);
            info = false;
        }
    }

    public void InfoVoltmeter()
    {
        if (!info)
        {
            voltmeterInfo.SetActive(true);
            info = true;
        }
        else
        {
            voltmeterInfo.SetActive(false);
            info = false;
        }
    }

    public void InfoSupportShop()
    {
        if (!info)
        {
            supportShopInfo.SetActive(true);
            info = true;
        }
        else
        {
            supportShopInfo.SetActive(false);
            info = false;
        }
    }

    public void InfoBattery()
    {
        if (!info)
        {
            batteryInfo.SetActive(true);
            info = true;
        }
        else
        {
            batteryInfo.SetActive(false);
            info = false;
        }
    }

    public void YouTubeAmmeter()
    {
        if (!youtube)
        {
            ammeterYouTube.SetActive(true);
            youtube = true;
        }
        else
        {
            ammeterYouTube.SetActive(false);
            youtube = false;
        }
    }

    public void YouTubeVoltmeter()
    {
        if (!youtube)
        {
            voltmeterYouTube.SetActive(true);
            youtube = true;
        }
        else
        {
            voltmeterYouTube.SetActive(false);
            youtube = false;
        }
    }

    public void YouTubeSupportShop()
    {
        if (!youtube)
        {
            supportShopYouTube.SetActive(true);
            youtube = true;
        }
        else
        {
            supportShopYouTube.SetActive(false);
            youtube = false;
        }
    }

    public void YouTubeBattery()
    {
        if (!youtube)
        {
            batteryYouTube.SetActive(true);
            youtube = true;
        }
        else
        {
            batteryYouTube.SetActive(false);
            youtube = false;
        }
    }

    public void LinkAmmeter()
    {
        if (!link)
        {
            ammeterLink.SetActive(true);
            link = true;
        }
        else
        {
            ammeterLink.SetActive(false);
            link = false;
        }
    }

    public void LinkVoltmeter()
    {
        if (!link)
        {
            voltmeterLink.SetActive(true);
            link = true;
        }
        else
        {
            voltmeterLink.SetActive(false);
            link = false;
        }
    }

    public void LinkSupportShop()
    {
        if (!link)
        {
            supportShopLink.SetActive(true);
            link = true;
        }
        else
        {
            supportShopLink.SetActive(false);
            link = false;
        }
    }

    public void LinkBattery()
    {
        if (!link)
        {
            batteryLink.SetActive(true);
            link = true;
        }
        else
        {
            batteryLink.SetActive(false);
            link = false;
        }
    }

    public void WikipediaAmmeter()
    {
        Application.OpenURL("https://uk.wikipedia.org/wiki/Амперметр");
    }

    public void PortalAmmeter()
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

    public void WikipediaBattery()
    {
        Application.OpenURL("https://uk.wikipedia.org/wiki/Електрорушійна_сила");
    }

    public void WikipediaBatter2()
    {
        Application.OpenURL("https://uk.wikipedia.org/wiki/Джерело_живлення");
    }

}
