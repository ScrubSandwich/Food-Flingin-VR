using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private static bool hasStarted;

    public Text stopwatch;
    private float minutes, seconds, totalTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        hasStarted = ControllerGrabObject.started;

        Debug.Log("Start?: " + hasStarted);
        if (hasStarted)
        {
            totalTime += Time.deltaTime;

            minutes = (int)((totalTime % 3600) / 60);
            seconds = (int)(totalTime % 60);
            stopwatch.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        }
    }
}
