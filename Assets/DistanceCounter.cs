using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceCounter : MonoBehaviour
{
    public GameObject startPoint;
    float timer = 0;
    public GameObject endpoint;
    public Rigidbody2D ball;
    // Update is called once per frame
    void Update()
    {
        //timer = Time.deltaTime;
        //float TimeRound = Mathf.Round(timer);

    }
    private void OnGUI()
    {
        float height = endpoint.transform.position.y - startPoint.transform.position.y;
        Debug.Log(height);
        float travelHeight = height - ball.transform.position.y;
        float DistRound = Mathf.Round(travelHeight);
        GUI.Label(new Rect(10, 10, 100, 20), DistRound.ToString());
    }
}
