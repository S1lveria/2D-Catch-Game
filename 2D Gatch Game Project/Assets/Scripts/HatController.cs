using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatController : MonoBehaviour
{
    public Camera cam;
	private Rigidbody2D rb;
	private float maxWidth;

	void Start ()
    {
		rb = GetComponent<Rigidbody2D>();

		if(cam == null)
        {
            cam = Camera.main;
        }

		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
		Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner);
		maxWidth = targetWidth.x;
	}
	
	// Update is called once per physics timestep
	void FixedUpdate ()
    {
        Vector3 rawPosition = cam.ScreenToWorldPoint (Input.mousePosition);
        Vector3 targetPosition = new Vector3 (rawPosition.x, 0.0f, 0.0f);
		float targetWidth = Mathf.Clamp (targetPosition.x, -maxWidth, maxWidth);
		targetPosition = new Vector3 (targetWidth, targetPosition.y, targetPosition.z);
		rb.MovePosition (targetPosition);
    }
}
