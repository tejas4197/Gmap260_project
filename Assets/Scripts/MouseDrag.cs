using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag: MonoBehaviour {
    Vector3 dist;
    float posx;
    float posy;

    void OnMouseDown () {
        dist = Camera.main.WorldToScreenPoint(transform.position);
        posx = Input.mousePosition.x - dist.x;
        posy = Input.mousePosition.y - dist.y;
    }
	
	void OnMouseDrag () {
        Vector3 cPos = new Vector3(Input.mousePosition.x - posx, Input.mousePosition.y - posy, dist.z);
        Vector3 wPos = Camera.main.ScreenToViewportPoint(cPos);
        transform.position = wPos;
	}
}
