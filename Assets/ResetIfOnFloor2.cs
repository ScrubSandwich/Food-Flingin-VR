using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetIfOnFloor2 : MonoBehaviour
{

    Vector3 originalLocation;
    Rigidbody rb;
    int TIMER = 150;

    void Start()
    {
        originalLocation = gameObject.transform.position;
        rb = gameObject.GetComponent<Rigidbody>();
        Debug.Log(gameObject.tag); 
    }

    bool same(float a, float b)
    {
        if (Mathf.Abs(a -  b) < 0.3)
        {
            return true;
        }

        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag.Equals("Leek")) {
            Debug.Log("__________________");
            Debug.Log((gameObject.transform.position.y));
            Debug.Log((originalLocation.y));
        }

        // If laying on floor too long, reset position to back on the table
        if (gameObject.transform.position.y <= 0.4 || rb.velocity.magnitude <= 0.4f)
        {
            if (!same(gameObject.transform.position.y, originalLocation.y) && !same(gameObject.transform.position.x, originalLocation.x) && !same(gameObject.transform.position.z,originalLocation.z)) {
                if (TIMER <= 0)
                {
                    gameObject.transform.position = originalLocation;
                    TIMER = 150;
                }

                TIMER--;
            }
        }

               
    }
}
