using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    public Vector3 offset;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void LateUpdate()
    {
        offset = transform.position - player.transform.position;

        if (player.transform.position.y > gameObject.transform.position.y)
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y - offset.y, transform.position.z);
    }
}
