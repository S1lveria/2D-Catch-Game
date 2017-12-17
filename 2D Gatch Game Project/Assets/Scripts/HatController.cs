using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatController : MonoBehaviour
{

    public Camera cam;

	void Start ()
    {
		if(cam == null)
        {
            cam = Camera.main;
        }
	}
	
	// Update is called once per physics timestep
	void FixUpdate ()
    {
        Vector3 rawPosition = cam.ScreenToWorldPoint(Input.mousePosition);
    }
}
