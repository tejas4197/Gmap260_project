using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallForce : MonoBehaviour {
    public Rigidbody2D rb;
    public float force;

	// Use this for initialization
	void Start () {
        rb.AddForce(new Vector2(0, force), ForceMode2D.Impulse);

    }

    // Update is called once per frame
    void Update () {
		
	}
}
