using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public Camera cam;
	private float maxWidth;

	void Start ()
	{
		if(cam == null)
		{
			cam = Camera.main;
		}
		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
		Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner);
		float hatWidth = GetComponent<Renderer>().bounds.extents.x;
		maxWidth = targetWidth.x - hatWidth;

	}
}
