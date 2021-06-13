using UnityEngine;
using System.Collections;

public class PickupObject : MonoBehaviour {

	public GameObject PickPotionButton;
	public GameObject DropPotionButton;
	public GameObject WireBox;
	public GameObject _WireRedBox;
	public GameObject _WireBlueBox;
	public GameObject WireBattery;
	public GameObject _WireRedBattery;
	public GameObject _WireBlueBattery;
	public GameObject WireLamp;
	public GameObject _WireRedLamp;
	public GameObject _WireBlueLamp;
	public GameObject WireResistor;
	public GameObject WireRedSwitch1;
	public GameObject WireRedSwitch2;
	public GameObject WireBlueSwitch1;
	public GameObject WireBlueSwitch2;
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
		if(carrying) {
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
					WireBox.SetActive(false);
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
					WireResistor.SetActive(false);
					resistors = false;
				}
			}
		}
	}

	public void resetWire()
    {
		_WireRedBox.SetActive(false);
		_WireBlueBox.SetActive(false);
		_WireRedBattery.SetActive(false);
		_WireBlueBattery.SetActive(false);
		_WireRedLamp.SetActive(false);
		_WireBlueLamp.SetActive(false);
		WireRedSwitch1.SetActive(false);
		WireRedSwitch2.SetActive(false);
		WireBlueSwitch1.SetActive(false);
		WireBlueSwitch2.SetActive(false);
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

