using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParentFood : MonoBehaviour
{
    public CreateFood[] pots;

    public Text stopwatch;
    private float minutes, seconds;

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
        stopwatch = GetComponent<Text>() as Text;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("TOTAL SCORE: " + total);

        minutes = (int)(Time.deltaTime / 60f);
        seconds = (int)(Time.deltaTime % 60);
        stopwatch.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}
