using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class PolygonField : MonoBehaviour {

	public GameObject[] go_raw;

	private Vector2[] go_points;
	private GameObject[] go_n;

	private LineRenderer lineRenderer;
	private MeshFilter filter;

	void Start () {
		lineRenderer = gameObject.GetComponent<LineRenderer>();
		filter = gameObject.GetComponent<MeshFilter> ();
	}

	void Update () {
		getAllAvailablePoints ();
		draw ();
		drawLines ();
	}

	private void getAllAvailablePoints(){
		
		List<Vector2> vertices2DList = new List<Vector2>();
		List<GameObject> oList = new List<GameObject>();

		
		for(int i = 0; i < go_raw.Length; i++){
			if (go_raw [i] != null) {
				if (go_raw [i].GetComponent<MeshRenderer> ().enabled) {
					vertices2DList.Add (new Vector2 (go_raw [i].transform.position.x, go_raw [i].transform.position.y));
					oList.Add ( go_raw [i] );
				}
			}
		}

	
		
		go_points = vertices2DList.ToArray ();
		go_n = oList.ToArray ();
	}

	
	private void draw(){
		
		Vector2[] vertices2D = go_points;

		
		Vector3[] vertices = new Vector3[vertices2D.Length];
		for (int i = 0; i < vertices.Length; i++) {
			vertices[i] = new Vector3(go_n[i].transform.position.x, go_n[i].transform.position.y, go_n[i].transform.position.z);
		}

		
		Mesh msh = new Mesh();
		msh.vertices = vertices;
		msh.RecalculateNormals();
		msh.RecalculateBounds();

		
		filter.mesh = msh;
	}


	private void drawLines(){

		lineRenderer.positionCount = go_points.Length;

		for(int i = 0; i < go_points.Length; i++){
			lineRenderer.SetPosition(i, new Vector3(go_n[i].transform.position.x, go_n[i].transform.position.y, go_n[i].transform.position.z));
		}
	}

	
	// Pitagor theory
	private double distance(float x1, float y1, float x2, float y2){
		float a = Math.Abs(x1 - x2);
		float b = Math.Abs(y1 - y2);
		double c = Math.Sqrt(a*a + b*b);

		return c;
	}


	private Vector2 midPoint(float x1, float y1, float x2, float y2){
		float x = (x1 + x2) / 2;
		float y = (y1 + y2) / 2;
		return new Vector2 (x, y);
	}

	
	private double angle_zero(float x1, float y1, float x2, float y2){
		double xDiff = x2 - x1;
		double yDiff = y2 - y1;
		double d = Math.Atan2(yDiff, xDiff) * (180 / Math.PI);
		return d;
	}
}