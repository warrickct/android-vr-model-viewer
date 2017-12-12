using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;

public class VRInteractable : MonoBehaviour, IPointerClickHandler {

    //TODO: panel ref wont be set if no obj with VRInteractable when scene starts.
	public static ManipulateController manipulateController;

    public float xRotVelocity=5;
    public float yRotVelocity=5;
    public float zRotVelocity=5;

    public void Start(){
		this.gameObject.tag = "Model";
	}

    public void OnEnable(){
        if (manipulateController == null)
        {
            manipulateController = GameObject.Find("ManipulatePanel").GetComponent<ManipulateController>();
        }
    }

	public void Update(){
		transform.Rotate(xRotVelocity * Time.deltaTime, yRotVelocity * Time.deltaTime, zRotVelocity * Time.deltaTime);
	}

	//passes this gameobj ref to manipulate controller.
	public virtual void OnPointerClick(PointerEventData eventData){
		manipulateController.SetInteractiveItem (this.gameObject);
	}

    public void ChangeRotation(float newSpeed, char axis)
    {
        switch (axis)
        {
            case 'x':
                xRotVelocity = newSpeed;
                break;
            case 'y':
                yRotVelocity = newSpeed;
                break;
            case 'z':
                zRotVelocity = newSpeed;
                break;
            default:
                xRotVelocity = newSpeed;
                Debug.Log("no axis input. Defaulting to x axis");
                break;
        }
    }
}
