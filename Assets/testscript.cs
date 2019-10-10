using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testscript : MonoBehaviour
{
    //VARIABLES NEED TO BE SET IN INSPECTOR
    public GameObject lemon;
	
    Rigidbody rb;

    void Start()
    {
        lemon = GameObject.Find("Lemon");
        rb = lemon.GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, -1))
        {
			
            if (hit.collider.gameObject.tag == "Lemon")
            {
				rb.AddForce(1, 6, 6f, ForceMode.Impulse);
                rb.useGravity = true;
            }

            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
        }
    }
}
