using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public LineRenderer laser;
    public Transform trackingSpace;
    public Transform head;

    public LayerMask avoidLayerMask;

	// Use this for initialization
	void Start () {
        laser.enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        //on key down
        
        if (OVRInput.GetDown(OVRInput.Button.PrimaryTouchpad))
        {
            laser.enabled = true;
        }

        //Init laser start and end vars and controller activity status
        if (laser.enabled)
        {
            Vector3 start = Vector3.zero;
            Vector3 end = Vector3.zero;
            OVRInput.Controller controller = OVRInput.GetActiveController() & (OVRInput.Controller.LTrackedRemote | OVRInput.Controller.RTrackedRemote);
            //if controller is present: set laser start end based on controller
            if (controller != OVRInput.Controller.None)
            {
                var orientation = OVRInput.GetLocalControllerRotation(controller);
                var localStartPoint = OVRInput.GetLocalControllerPosition(controller);
                var localEndPoint = localStartPoint + ((orientation * Vector3.forward) * 50000.0f);
                Matrix4x4 localToWorld = trackingSpace.localToWorldMatrix;
                start = localToWorld.MultiplyPoint(localStartPoint);
                end = localToWorld.MultiplyPoint(localEndPoint);
                laser.name = "controller";
            }
            //else if controller not active: shoot from head
            else
            {
                start = head.position - Vector3.up * transform.localScale.magnitude * .1f;
                end = start + head.forward * 50000f;
                laser.name = "head";
            }


            //render the line from the previously calculated start and end positions.
            RaycastHit hit;
            if (Physics.Raycast(start, end, out hit, avoidLayerMask))
            {
                end = hit.point;
                //return if there is a control was released on the touch pad
                if (OVRInput.GetUp(OVRInput.Button.PrimaryTouchpad))
                {
                    //warrick end
                    Debug.Log("Hit " + hit.collider.name);
                    transform.position = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                }
            }
            laser.SetPosition(0, start);
            laser.SetPosition(1, end);
            laser.widthMultiplier = transform.localScale.magnitude * .02f;
        }
    }
}
