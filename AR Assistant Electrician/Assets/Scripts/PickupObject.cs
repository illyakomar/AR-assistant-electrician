using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class PickupObject : MonoBehaviour {

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

	public GameObject Lights;

	public TextMeshPro textInVoltmeter;

	public float distance;
	public float smooth;
	private bool box;
	private bool batterys;
	private bool lamps;
	private bool resistors;

	bool carrying;
	GameObject mainCamera;
	GameObject carriedObject;

	void Start () {
		PickPotionButton.SetActive (true);
		DropPotionButton.SetActive (false);
		mainCamera = GameObject.FindWithTag("MainCamera");
	}
	
	void Update () {
		onVoltmeterAndLamp();
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
				if (!box)
				{
					WireBox.SetActive(true);
					box = true;
				}
				else
				{
					WireController4.SetActive(false);
					WireController5.SetActive(false);
					WireBox.SetActive(false);
					textInVoltmeter.SetText("00.00");
					box = false;
				}
			}

			Battery battery = hit.collider.GetComponent<Battery>();
			if (battery != null)
			{
				if (!batterys)
				{
					WireBattery.SetActive(true);
					batterys = true;
				}
				else
				{
					WireBattery.SetActive(false);
					WireController1.SetActive(false);
					WireController3.SetActive(false);
					Lights.SetActive(false);
					batterys = false;
				}
			}

			Lamp lamp = hit.collider.GetComponent<Lamp>();
			if (lamp != null)
			{
				if (!lamps)
				{
					WireLamp.SetActive(true);
					lamps = true;
				}
				else
				{
					WireLamp.SetActive(false);
					WireController2.SetActive(false);
					WireController3.SetActive(false);
					WireController4.SetActive(false);
					WireController5.SetActive(false);
					Lights.SetActive(false);
					lamps = false;
				}
			}

			Resistores resistor = hit.collider.GetComponent<Resistores>();
			if (resistor != null)
			{
				if (!resistors)
				{
					WireResistor.SetActive(true);
					resistors = true;
				}
				else
				{
					WireController1.SetActive(false);
					WireController2.SetActive(false);
					WireResistor.SetActive(false);
					resistors = false;
				}
			}
		}
	}

	public void resetWire()
    {
		WireBox.SetActive(false);
		WireBattery.SetActive(false);
		WireLamp.SetActive(false);
		WireResistor.SetActive(false);
		Lights.SetActive(false);
		textInVoltmeter.SetText("00.00");
		WireController1.SetActive(false);
		WireController2.SetActive(false);
		WireController3.SetActive(false);
		WireController4.SetActive(false);
		WireController5.SetActive(false);
		ConnectButton1.gameObject.SetActive(false);
		ConnectButton2.gameObject.SetActive(false);
		ConnectButton3.gameObject.SetActive(false);
		ConnectButton4.gameObject.SetActive(false);
		ConnectButton5.gameObject.SetActive(false);
	}

	void onVoltmeterAndLamp()
    {
		if(WireController1.activeSelf && WireController2.activeSelf && WireController3.activeSelf && WireController4.activeSelf && WireController5.activeSelf)
        {
			textInVoltmeter.SetText("00.85");
			Lights.SetActive(true);
		}

		if (WireController1.activeSelf && WireController2.activeSelf && WireController3.activeSelf)
		{
			Lights.SetActive(true);
		}
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

