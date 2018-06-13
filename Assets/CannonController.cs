using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour {

    public GameObject Cannonball;
    public float RepeatRate;
    public float CannonballSpeed;

    Vector3 Placement;
    Vector3 Velocity;

	// Use this for initialization
	void Start () {
        float xOffset = gameObject.transform.rotation.y == 0 ? 2 : -2;
        Placement = gameObject.transform.position;
        Placement.y += 2.5f;
        Placement.x += xOffset;

        Velocity = Placement - (gameObject.transform.position + new Vector3(0, 1));
        Velocity = Velocity.normalized;

        InvokeRepeating("LaunchCannonball", 0.5f, RepeatRate);
	}
	
	void LaunchCannonball()
    {
        GameObject instantiatedCannonball = Instantiate(Cannonball, Placement, Quaternion.identity);
        Rigidbody2D rb = instantiatedCannonball.GetComponent<Rigidbody2D>();
        rb.AddForce(Velocity * CannonballSpeed);
    }
}
