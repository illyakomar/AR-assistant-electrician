using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using System.Linq;

public class PickupObject : MonoBehaviourPunCallbacks
{

	public GameObject PickPotionButton;
	public GameObject DropPotionButton;
	public GameObject WireBox;
	public GameObject WireBattery;
	public GameObject WireLamp;
	public GameObject WireResistor;

	public GameObject WireController1;
	public GameObject WireController2;
	public GameObject WireController3;
	public GameObject WireController4;
	public GameObject WireController5;

	public Button ConnectButton1;
	public Button ConnectButton2;
	public Button ConnectButton3;
	public Button ConnectButton4;
	public Button ConnectButton5;


	public Battery batteryWire;
	public Variable variableWire;
	public Lamp lampWire;
	public Resistores resistoresWire;


	public float distance;
	public float smooth;


	bool carrying;
	GameObject mainCamera;
	GameObject carriedObject;

	void Start ()
	{ 
		PickPotionButton.SetActive (true);
		DropPotionButton.SetActive (false);
		mainCamera = GameObject.FindWithTag("MainCamera");
	}
	
	void Update () {
		photonView.RPC("onVoltmeterAndLamp", RpcTarget.All);
		OnButtonActive();
		if (carrying) {
			carry(carriedObject);
		}
	}


	void rotateObject() {
		carriedObject.transform.Rotate(5,10,15);
	}
	
	void carry(GameObject o) {
		o.transform.position = Vector3.Lerp (o.transform.position, mainCamera.transform.position + mainCamera.transform.forward * distance, Time.deltaTime * smooth);
	}

	public void pickObject() {
		int x = Screen.width / 2;
		int y = Screen.height / 2;

		Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x,y));
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit)) {
			Pickupable p = hit.collider.GetComponent<Pickupable>();
			if (p != null) {
				Outline hoveredOutline = p.GetComponent<Outline>();
				carrying = true;
				carriedObject = p.gameObject;
				p.gameObject.GetComponent<Rigidbody>().isKinematic = false;
				PickPotionButton.SetActive (false);
				DropPotionButton.SetActive (true);
				hoveredOutline.OutlineWidth = 3;

			}
		}
	}

	[PunRPC]
	public void OnWireController1()
    {
		WireController1.SetActive(true);
    }

	[PunRPC]
	public void OnWireController2()
	{
		WireController2.SetActive(true);
	}

	[PunRPC]
	public void OnWireController3()
	{
		WireController3.SetActive(true);
	}

	[PunRPC]
	public void OnWireController4()
	{
		WireController4.SetActive(true);
	}

	[PunRPC]
	public void OnWireController5()
	{
		WireController5.SetActive(true);
	}

	[PunRPC]
	public void OffWireController1()
	{
		WireController1.SetActive(false);
	}

	[PunRPC]
	public void OffWireController2()
	{
		WireController2.SetActive(false);
	}

	[PunRPC]
	public void OffWireController3()
	{
		WireController3.SetActive(false);
	}

	[PunRPC]
	public void OffWireController4()
	{
		WireController4.SetActive(false);
	}

	[PunRPC]
	public void OffWireController5()
	{
		WireController5.SetActive(false);
	}

	[PunRPC]
	public void GiveWireBattery()
	{
		batteryWire.SetWire(true);
	}

	[PunRPC]
	public void DropWireBattery()
	{
		batteryWire.SetWire(false);
	}

	[PunRPC]
	public void GiveWireBox()
	{
		variableWire.SetWire(true);
	}

	[PunRPC]
	public void DropWireBox()
	{
		variableWire.SetWire(false);
	}
	[PunRPC]
	public void BoxTextOn()
	{
		variableWire.SetTextOn();
	}

	[PunRPC]
	public void BoxTextOff()
	{
		variableWire.SetTextOff();
	}

	[PunRPC]
	public void GiveWireLamp()
	{
		lampWire.SetWire(true);
	}

	[PunRPC]
	public void DropWireLamp()
	{
		lampWire.SetWire(false);
	}

	[PunRPC]
	public void GiveLightLamp()
	{
		lampWire.SetLightOn();
	}

	[PunRPC]
	public void DropLightLamp()
	{
		lampWire.SetLightOff();
	}

	[PunRPC]
	public void GiveWireResistors()
	{
		resistoresWire.SetWire(true);
	}

	[PunRPC]
	public void DropWireResistors()
	{
		resistoresWire.SetWire(false);
	}

	public void wireObject()
	{
		int x = Screen.width / 2;
		int y = Screen.height / 2;

		Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit))
		{
			Variable variable = hit.collider.GetComponent<Variable>();
			if (variable != null)
			{
				photonView.RPC("GiveWireBox", RpcTarget.All);
			}

			Battery battery = hit.collider.GetComponent<Battery>();
			if (battery != null)
			{
				photonView.RPC("GiveWireBattery", RpcTarget.All);
			}

			Lamp lamp = hit.collider.GetComponent<Lamp>();
			if (lamp != null)
			{
				photonView.RPC("GiveWireLamp", RpcTarget.All);
			}

			Resistores resistor = hit.collider.GetComponent<Resistores>();
			if (resistor != null)
			{
				photonView.RPC("GiveWireResistors", RpcTarget.All);
			}
		}
	}

	public void resetWire()
    {
		photonView.RPC("DropWireBattery", RpcTarget.All);
		photonView.RPC("DropWireBox", RpcTarget.All);
		photonView.RPC("DropWireLamp", RpcTarget.All);
		photonView.RPC("DropWireResistors", RpcTarget.All);
		photonView.RPC("OffWireController1", RpcTarget.All);
		photonView.RPC("OffWireController2", RpcTarget.All);
		photonView.RPC("OffWireController3", RpcTarget.All);
		photonView.RPC("OffWireController4", RpcTarget.All);
		photonView.RPC("OffWireController5", RpcTarget.All);
		photonView.RPC("DropLightLamp", RpcTarget.All);
		photonView.RPC("BoxTextOff", RpcTarget.All);
		ConnectButton1.gameObject.SetActive(false);
		ConnectButton2.gameObject.SetActive(false);
		ConnectButton3.gameObject.SetActive(false);
		ConnectButton4.gameObject.SetActive(false);
		ConnectButton5.gameObject.SetActive(false);
	}

	[PunRPC]
	void onVoltmeterAndLamp()
    {
		if(WireController1.activeSelf && WireController2.activeSelf && WireController3.activeSelf && WireController4.activeSelf && WireController5.activeSelf)
        {
			photonView.RPC("GiveLightLamp", RpcTarget.All);
			photonView.RPC("BoxTextOn", RpcTarget.All);
		}

		if (WireController1.activeSelf && WireController2.activeSelf && WireController3.activeSelf)
		{
			photonView.RPC("GiveLightLamp", RpcTarget.All);
		}
	}

	public void OnClickWireController1()
    {
		photonView.RPC("OnWireController1", RpcTarget.All);
	}

	public void OnClickWireController2()
	{
		photonView.RPC("OnWireController2", RpcTarget.All);
	}

	public void OnClickWireController3()
	{
		photonView.RPC("OnWireController3", RpcTarget.All);
	}

	public void OnClickWireController4()
	{
		photonView.RPC("OnWireController4", RpcTarget.All);
	}

	public void OnClickWireController5()
	{
		photonView.RPC("OnWireController5", RpcTarget.All);
	}

	void OnButtonActive()
    {
		if (WireBattery.activeSelf && WireResistor.activeSelf)
		{
			ConnectButton1.gameObject.SetActive(true);
		}
		else
        {
			ConnectButton1.gameObject.SetActive(false);
		}

		if (WireBattery.activeSelf && WireLamp.activeSelf)
		{
			ConnectButton3.gameObject.SetActive(true);
		}
		else
        {
			ConnectButton3.gameObject.SetActive(false);
		}

		if (WireResistor.activeSelf && WireLamp.activeSelf)
		{
			ConnectButton2.gameObject.SetActive(true);
		}
		else
		{
			ConnectButton2.gameObject.SetActive(false);
		}

		if (WireLamp.activeSelf && WireBox.activeSelf)
		{
			ConnectButton4.gameObject.SetActive(true);
			ConnectButton5.gameObject.SetActive(true);
		}
		else
        {
			ConnectButton4.gameObject.SetActive(false);
			ConnectButton5.gameObject.SetActive(false);
		}
	}

	void checkDrop() {
		if(Input.GetMouseButtonDown(1)) {
			dropObject();
		}
	}
	
	public void dropObject() {
		Outline hoveredOutlineOff = carriedObject.gameObject.GetComponent<Outline>();
		carrying = false;
		if (carriedObject != null)
		{
			hoveredOutlineOff.OutlineWidth = 0;
			carriedObject.gameObject.GetComponent<Rigidbody>().isKinematic = true;
		}
		carriedObject = null;
		PickPotionButton.SetActive (true);
		DropPotionButton.SetActive (false);
	}

}

