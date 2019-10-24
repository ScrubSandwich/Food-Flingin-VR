using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private static bool hasStarted;
    private static bool hasEnded;

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
        hasEnded = ParentFood.ended;

        if (hasEnded)
        {
            hasStarted = false;
            stopwatch.text = minutes.ToString("00") + ":" + seconds.ToString("00");

        } else if (hasStarted)
        {
            totalTime += Time.deltaTime;

            minutes = (int)((totalTime % 3600) / 60);
            seconds = (int)(totalTime % 60);
            stopwatch.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        }

    }
}
