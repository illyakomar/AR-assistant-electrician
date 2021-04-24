using UnityEngine;
using System.Collections;

public class PickupObject : MonoBehaviour {

	public GameObject PickPotionButton;
	public GameObject DropPotionButton;
	public float distance;
	public float smooth;

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
		if(Physics.Raycast(ray, out hit)) {
			Pickupable p = hit.collider.GetComponent<Pickupable>();
			if(p != null) {
				carrying = true;
				carriedObject = p.gameObject;
				p.gameObject.GetComponent<Rigidbody>().isKinematic = true;
				PickPotionButton.SetActive (false);
				DropPotionButton.SetActive (true);

			}
		}
	}
	
	void checkDrop() {
		if(Input.GetMouseButtonDown(1)) {
			dropObject();
		}
	}
	
	public void dropObject() {
		carrying = false;
		if(carriedObject != null)
			carriedObject.gameObject.GetComponent<Rigidbody>().isKinematic = false;
		carriedObject = null;
		PickPotionButton.SetActive (true);
		DropPotionButton.SetActive (false);
	}
}

