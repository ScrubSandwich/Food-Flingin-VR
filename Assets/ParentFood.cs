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
    GameObject DisplayTimerBoard;

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
        int layerMask = 1 << 8;
        layerMask = ~layerMask;

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))

        {
            Vector3 fwd = transform.TransformDirection(Vector3.forward);
            Debug.Log(hit.collider.name);

            Debug.DrawRay(transform.position, fwd * 100, Color.blue);

            if (hit.collider == DisplayTimerBoard)
            {
                Debug.Log("BIG WIN");
            }

            if (hit.collider.gameObject.tag == "Begin")
            {
                Debug.Log("_______________________________________");
            }
        }


        //Debug.Log("TOTAL SCORE: " + total);

        //while (total < 3)
        //{
        //    totalTime += Time.deltaTime;

        //    minutes = (int)((totalTime % 3600) / 60);
        //    seconds = (int)(totalTime % 60);
        //    stopwatch.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        //}

    }


}
