using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag: MonoBehaviour {

	 public float distance = 5;

    private void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
