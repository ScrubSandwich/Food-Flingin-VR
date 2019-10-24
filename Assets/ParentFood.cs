using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParentFood : MonoBehaviour
{
    public CreateFood[] pots;
    public static bool ended = false;

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

    }

    // Update is called once per frame
    void Update()
    {
        if (total >= 3)
        {
            ended = true;
        }
    }


}
