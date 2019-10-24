
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class ControllerGrabObject : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean GrabGrip;

    private GameObject collidingObject;
    private GameObject objectInHand;
    private GameObject lastObject;

    Vector3 originalPos;
    int timeObjectIsOutOfHand = 0;
    int TIME_UNTIL_OBJECT_RESPAWNS = 200;

    private void SetCollidingObject(Collider col)
    {
        if (collidingObject || !col.GetComponent<Rigidbody>())
        {
            return;
        }

        collidingObject = col.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (GrabGrip.GetLastStateDown(handType))
        {
            if (collidingObject)
            {
                GrabObject();
            }
        }

        if (GrabGrip.GetLastStateUp(handType))
        {
            if (objectInHand)
            {
                ReleaseObject();
            }
        }

        Debug.Log(timeObjectIsOutOfHand);

        // This is for resetting the object back to its starting position
        if (lastObject != null)
        {
            timeObjectIsOutOfHand++;

            if (timeObjectIsOutOfHand > TIME_UNTIL_OBJECT_RESPAWNS)
            {
                lastObject.transform.position = originalPos;
                Rigidbody rigidbody = lastObject.GetComponent<Rigidbody>();
                rigidbody.velocity = new Vector3(0, 0, 0);
                timeObjectIsOutOfHand = 0;
                lastObject = null;
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        SetCollidingObject(other);
    }

    public void OnTriggerStay(Collider other)
    {
        SetCollidingObject(other);
    }

    public void OnTriggerExit(Collider other)
    {
        if (!collidingObject)
        {
            return;
        }

        collidingObject = null;
    }

    private void GrabObject()
    {
        objectInHand = collidingObject;
        originalPos = gameObject.transform.position;
        collidingObject = null;

        var joint = AddFixedJoint();
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
    }

    private FixedJoint AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;
    }

    private void ReleaseObject()
    {
        Rigidbody rigidbody;
        if (GetComponent<FixedJoint>())
        {
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());

            rigidbody = objectInHand.GetComponent<Rigidbody>();

            Vector3 oldVec = controllerPose.GetVelocity();

            oldVec = Quaternion.Euler(0, 90, 0) * oldVec;

            Vector3 n = new Vector3(2, 1, 2);
            oldVec = Vector3.Scale(oldVec, n);

            rigidbody.velocity = oldVec;
        }

        lastObject = objectInHand;

        objectInHand = null;
    }
}
