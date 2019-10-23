using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParentFood : MonoBehaviour
{
    public CreateFood[] pots;

    public Text stopwatch;
    private float minutes, seconds, totalTime;
    bool hasStarted;

    public int total
    {
        get
        {
            int t = 0;
            for (int i = 0; i < 3; i++)
            {
                t += pots[i].totalScore;
            }
            return t;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        stopwatch = GetComponent<Text>();
        hasStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        Raycast hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            Vector3 fwd = transform.TransformDirection(Vector3.forward);

            Debug.DrawRay(transform.position, fwd * 100, Color.blue);

            if (hit.collider.gameObject.tag == "Begin")
            {

            }
        }


        Debug.Log("TOTAL SCORE: " + total);

        while (total < 3)
        {
            totalTime += Time.deltaTime;

            minutes = (int)((totalTime % 3600) / 60);
            seconds = (int)(totalTime % 60);
            stopwatch.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        }
        
    }


}
