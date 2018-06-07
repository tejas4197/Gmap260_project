using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceCounter : MonoBehaviour
{
    Vector3 startPoint;
    float timer = 0;
    // Update is called once per frame
    void Update()
    {
        timer = Time.deltaTime;
        float TimeRound = Mathf.Round(timer);

    }
    private void OnGUI()
    {
        timer = Time.deltaTime;
        float TimeRound = Mathf.Round(timer);
        float meters = transform.position.y - startPoint.y;
        float DistRound = Mathf.Round(meters);
        GUI.Label(new Rect(10, 10, 100, 20), DistRound.ToString() + " " + TimeRound);
    }
}
