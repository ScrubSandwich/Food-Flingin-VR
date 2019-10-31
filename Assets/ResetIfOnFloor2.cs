using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetIfOnFloor2 : MonoBehaviour
{

    Vector3 originalLocation;
    int TIMER = 150;

    void Start()
    {
        originalLocation = gameObject.transform.position;
        Debug.Log(gameObject.tag); 
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag.Equals("Leek")) {
            Debug.Log(gameObject.transform.position.y);
        }

        // If laying on floor too long, reset position to back on the table
        if (gameObject.transform.position.y <= 0.2)
        {
            if (TIMER <= 0)
            {
                gameObject.transform.position = originalLocation;
                TIMER = 150;
            }

            TIMER--;
        }

               
    }
}
