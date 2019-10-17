using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PickUp : MonoBehaviour
{
    public SteamVR_Action_Boolean GrabGrip;
    public SteamVR_Input_Sources handType;

    float throwForce = 1f;
    Vector3 objectPosition;
    float distanceBetweenPlayerAndObject;

    public bool canHold = true;
    public GameObject item;
    public GameObject tempParent;
    public bool isHolding = false;

    private Vector3 _currentGrabbedLocation;

    void Start()
    {
        GrabGrip.onStateUp += onTriggerUp;
        item = null;
        _currentGrabbedLocation = new Vector3();

    }

    // Update is called once per frame
    void Update()
    {
        if (GetGrab())
        {
            print("grab " + handType);
        }

        if (item != null)
        {
            _currentGrabbedLocation = item.transform.position;
        }

        distanceBetweenPlayerAndObject = Vector3.Distance(item.transform.position, tempParent.transform.position);

        if (distanceBetweenPlayerAndObject > 1f)
        {
            isHolding = false;

        }
        if (isHolding == true)
        {
            item.GetComponent<Rigidbody>().velocity = Vector3.zero;
            item.GetComponent<Rigidbody>().angularVelocity= Vector3.zero;
            item.transform.SetParent(tempParent.transform);

            if (false) // TODO
            {
                item.GetComponent<Rigidbody>().AddForce(tempParent.transform.forward * throwForce);
                isHolding = false;
            }
        }
        else
        {
            objectPosition = item.transform.position;
            item.transform.SetParent(null);
            item.GetComponent<Rigidbody>().useGravity = true;
            item.transform.position = objectPosition;
        }
    }

    public bool GetGrab() // 2
    {
        return GrabGrip.GetState(handType);
    }

    private void onTriggerDown()
    {
        if (distanceBetweenPlayerAndObject <= 1f)
        {
            isHolding = true;
            item.GetComponent<Rigidbody>().useGravity = false;
            item.GetComponent<Rigidbody>().detectCollisions = true;
        }

    }

    private void onTriggerUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {

    }
}
