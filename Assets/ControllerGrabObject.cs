
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
        if (GetComponent<FixedJoint>())
        {
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());

            Rigidbody rigidbody = objectInHand.GetComponent<Rigidbody>();

            Vector3 oldVec = controllerPose.GetVelocity();

            oldVec = Quaternion.Euler(0, 90, 0) * oldVec;

            Vector3 n = new Vector3(2, 1, 2);
            oldVec = Vector3.Scale(oldVec, n);

            rigidbody.velocity = oldVec;
        }

        objectInHand = null;
    }
}
