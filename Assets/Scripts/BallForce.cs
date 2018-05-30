using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallForce : MonoBehaviour {
    public Rigidbody rb;
    public float force;

	// Use this for initialization
	void Start () {
        rb.AddForce(0, force, 0, ForceMode.VelocityChange);

    }

    // Update is called once per frame
    void Update () {
		
	}
}
