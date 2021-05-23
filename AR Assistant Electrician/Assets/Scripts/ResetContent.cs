using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetContent : MonoBehaviour
{
	public Transform[] potions;
	List<Vector3> position = new List<Vector3>();
    void Start()
    {
		for (int i = 0; i < potions.Length; i++) {
			position.Add (potions[i].localPosition);
		}
    }

  
	public  void Reset()
    {
		for (int i = 0; i < potions.Length; i++) {
			potions [i].localPosition = position [i];
			potions [i].gameObject.SetActive (true);
		}
    }
}
